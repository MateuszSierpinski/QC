using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Data;
using System.Windows.Forms;
using System.Drawing.Design;
using System.ComponentModel.Design;
using System.Runtime.InteropServices;
using System.Diagnostics;
using System.IO;
using QC;

namespace FlatTabControl
{
	/// <summary>
	/// Summary description for FlatTabControl.
	/// </summary>
	[ToolboxBitmap(typeof(System.Windows.Forms.TabControl))] //,
		//Designer(typeof(Designers.FlatTabControlDesigner))]
	

	public class FlatTabControl : System.Windows.Forms.TabControl
	{
        private TabPage HoverTab()
        {
            for (int index = 0; index <= this.TabCount - 1; index++)
            {
                if (this.GetTabRect(index).Contains(this.PointToClient(Cursor.Position)))
                    return this.TabPages[index];
            }
            return null;
        }

        private void SwapTabPages(TabPage tp1, TabPage tp2)
        {
            int Index1 = this.TabPages.IndexOf(tp1);
            int Index2 = this.TabPages.IndexOf(tp2);
            this.TabPages[Index1] = tp2;
            this.TabPages[Index2] = tp1;
        }

        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.Container components = null;
		private SubClass scUpDown = null;
		private bool bUpDown; // true when the button UpDown is required
		private ImageList leftRightImages = null;
		private const int nMargin = 5;
		private Color mBackColor = Color.FromArgb(50,50,50);
        private Point DragStartPosition = Point.Empty;

        public FlatTabControl()
		{
			// This call is required by the Windows.Forms Form Designer.
			InitializeComponent();

            
            // double buffering
            this.SetStyle(ControlStyles.UserPaint, true);
			this.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
			this.SetStyle(ControlStyles.DoubleBuffer, true);
			this.SetStyle(ControlStyles.ResizeRedraw, true);
			this.SetStyle(ControlStyles.SupportsTransparentBackColor, true);

			bUpDown = false;

			this.ControlAdded += new ControlEventHandler(FlatTabControl_ControlAdded);
			this.ControlRemoved += new ControlEventHandler(FlatTabControl_ControlRemoved);
			this.SelectedIndexChanged += new EventHandler(FlatTabControl_SelectedIndexChanged);

			leftRightImages = new ImageList();
			//leftRightImages.ImageSize = new Size(16, 16); // default

			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(FlatTabControl));
			Bitmap updownImage = ((System.Drawing.Bitmap)(resources.GetObject("TabIcons.bmp")));
			
			if (updownImage != null)
			{
				updownImage.MakeTransparent(Color.White);
				leftRightImages.Images.AddStrip(updownImage);
			}

            this.AllowDrop = true;
            this.ItemSize = new Size(0, 30);
            this.MouseDown += FlatTabControl_MouseDown;
            this.DragOver += FlatTabControl_DragOver;
            this.MouseMove += FlatTabControl_MouseMove;
            

        }
        private void FlatTabControl_MouseDown(object sender, MouseEventArgs e)
        {
            this.AllowDrop = true;
            Rectangle r = this.GetTabRect(this.SelectedIndex);
            Rectangle closeButton = new Rectangle(r.Right - 15, r.Top + 10, 40, 15);
            if (closeButton.Contains(e.Location))
            {
                this.TabPages.Remove(this.SelectedTab);

                if (this.TabCount == 0)
                {
                    this.Visible = false;
                }
            }

            DragStartPosition = new Point(e.X, e.Y);
        }

        private void FlatTabControl_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left) return;

            Rectangle r = new Rectangle(DragStartPosition, Size.Empty);
            r.Inflate(SystemInformation.DragSize);

            TabPage tp = HoverTab();

            if (tp != null)
            {
                if (!r.Contains(e.X, e.Y))
                    this.DoDragDrop(tp, DragDropEffects.All);
            }

            DragStartPosition = Point.Empty;
        }

        private void FlatTabControl_DragOver(object sender, DragEventArgs e)
        {
            TabPage hover_Tab = HoverTab();
            if (hover_Tab == null)
                e.Effect = DragDropEffects.None;
            else
            {
                if (e.Data.GetDataPresent(typeof(TabPage)))
                {
                    e.Effect = DragDropEffects.Move;
                    TabPage drag_tab = (TabPage)e.Data.GetData(typeof(TabPage));

                    if (hover_Tab == drag_tab) return;

                    Rectangle TabRect = this.GetTabRect(this.TabPages.IndexOf(hover_Tab));
                    TabRect.Inflate(-3, -3);
                    if (TabRect.Contains(this.PointToClient(new Point(e.X, e.Y))))
                    {
                        SwapTabPages(drag_tab, hover_Tab);
                        this.SelectedTab = drag_tab;
                    }
                }
            }
        }



        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if(components != null)
				{
					components.Dispose();
				}

				leftRightImages.Dispose();
			}
			base.Dispose( disposing );
		}

		protected override void OnPaint(PaintEventArgs e)
		{
			base.OnPaint(e); 
			
			DrawControl(e.Graphics);
		}

		internal void DrawControl(Graphics g)
		{
			if (!Visible)
				return;

			Rectangle TabControlArea = this.ClientRectangle;
			Rectangle TabArea = this.DisplayRectangle;

			//----------------------------
			// fill client area
			Brush br = new SolidBrush(mBackColor); //(SystemColors.Control); UPDATED
			g.FillRectangle(br, TabControlArea);
			br.Dispose();
			//----------------------------

			//----------------------------
			//// draw border
			//int nDelta = SystemInformation.Border3DSize.Width;

			//Pen border = new Pen(SystemColors.ControlDark);
			//TabArea.Inflate(nDelta, nDelta);
			//g.DrawRectangle(border, TabArea);
			//border.Dispose();
			//----------------------------


			//----------------------------
			// clip region for drawing tabs
			Region rsaved = g.Clip;
			Rectangle rreg;

			int nWidth = TabArea.Width + nMargin;
			if (bUpDown)
			{
				// exclude updown control for painting
				if (Win32.IsWindowVisible(scUpDown.Handle))
				{
					Rectangle rupdown = new Rectangle();
					Win32.GetWindowRect(scUpDown.Handle, ref rupdown);
					Rectangle rupdown2 = this.RectangleToClient(rupdown);

					nWidth = rupdown2.X;
				}
			}

			rreg = new Rectangle(TabArea.Left, TabControlArea.Top, nWidth - nMargin, TabControlArea.Height);

			g.SetClip(rreg);

			// draw tabs
			for (int i = 0; i < this.TabCount; i++)
				DrawTab(g, this.TabPages[i], i);

			g.Clip = rsaved;
			//----------------------------


			//----------------------------
			// draw background to cover flat border areas
			//if (this.SelectedTab != null)
			//{
				//TabPage tabPage = this.SelectedTab;
				//Color color = tabPage.BackColor;
				//border = new Pen(color);
				
				//TabArea.Offset(1, 1);
				//TabArea.Width -= 2;
				//TabArea.Height -= 2;
				
				//g.DrawRectangle(border, TabArea);
				//TabArea.Width -= 1;
				//TabArea.Height -= 1;
				//g.DrawRectangle(border, TabArea);

				//border.Dispose();
			//}
			//----------------------------
		}

		internal void DrawTab(Graphics g, TabPage tabPage, int nIndex)
		{
			Rectangle recBounds = this.GetTabRect(nIndex);
			RectangleF tabTextArea = (RectangleF)this.GetTabRect(nIndex);

			bool bSelected = (this.SelectedIndex == nIndex);

			Point[] pt = new Point[7];

		    pt[0] = new Point(recBounds.Left, recBounds.Bottom);
		    pt[1] = new Point(recBounds.Left, recBounds.Top);
		    pt[2] = new Point(recBounds.Left , recBounds.Top);
		    pt[3] = new Point(recBounds.Right , recBounds.Top);
		    pt[4] = new Point(recBounds.Right, recBounds.Top);
			pt[5] = new Point(recBounds.Right, recBounds.Bottom);
			pt[6] = new Point(recBounds.Left, recBounds.Bottom);
			


			//----------------------------
			// fill this tab with background color
			Brush br = new SolidBrush(Color.FromArgb(50,50,50));
			g.FillPolygon(br, pt);
			br.Dispose();
			//----------------------------

			//----------------------------
			// draw border
			//g.DrawRectangle(SystemPens.ControlDark, recBounds);
			//g.DrawPolygon(SystemPens.ControlDark, pt);

			if (bSelected)
			{
                br = new SolidBrush(Color.FromArgb(50, 50, 50));
                g.FillPolygon(br, pt);
                br.Dispose();
                //----------------------------
                // clear bottom lines
                Pen pen = new Pen(Color.FromArgb(0, 160, 233));


                g.DrawLine(pen, recBounds.Left + 1, recBounds.Bottom - 4, recBounds.Right - 1, recBounds.Bottom - 4);
                g.DrawLine(pen, recBounds.Left + 1, recBounds.Bottom - 3, recBounds.Right - 1, recBounds.Bottom - 3);

                pen.Dispose();
				//----------------------------
			}
			//----------------------------

			//----------------------------
			// draw tab's icon
			//if ((tabPage.ImageIndex >= 0) && (ImageList != null) && (ImageList.Images[tabPage.ImageIndex] != null))
			//{
				int nLeftMargin = 5;
				int nRightMargin = 2;
                
                var X = TabIcons.ImageList.Images[0];
                Image img = X;

                float nAdj = (float)(nLeftMargin + img.Width + nRightMargin);
                
                tabTextArea.X = recBounds.X;
                tabTextArea.Width -= nAdj;

                Rectangle rimage = new Rectangle(recBounds.X + Convert.ToInt32(tabTextArea.Width) + 1, recBounds.Y + 1, img.Width, img.Height);
                rimage.Y += (recBounds.Height - img.Height) / 2;
            // adjust rectangles




            // draw icon
            g.DrawImage(img, rimage);
			//}
			//----------------------------

			//----------------------------
			// draw string
			StringFormat stringFormat = new StringFormat();
			stringFormat.Alignment = StringAlignment.Center;  
			stringFormat.LineAlignment = StringAlignment.Center;
            Font font = new Font("Century Gothic",9F);

            br = new SolidBrush(Color.DimGray);
            g.DrawString(tabPage.Text, font, br, tabTextArea, stringFormat);

            if (bSelected)
            {
                br = new SolidBrush(Color.White);
                g.DrawString(tabPage.Text, font, br, tabTextArea, stringFormat);
            }

                
			//----------------------------
		}

		internal void DrawIcons(Graphics g)
		{
			if ((leftRightImages == null) || (leftRightImages.Images.Count != 4))
				return;

			//----------------------------
			// calc positions
			Rectangle TabControlArea = this.ClientRectangle;

			Rectangle r0 = new Rectangle();
			Win32.GetClientRect(scUpDown.Handle, ref r0);

			Brush br = new SolidBrush(SystemColors.Control);
			g.FillRectangle(br, r0);
			br.Dispose();
			
			//Pen border = new Pen(SystemColors.ControlDark);
			//Rectangle rborder = r0;
			//rborder.Inflate(-1, -1);
			//g.DrawRectangle(border, rborder);
			//border.Dispose();

			int nMiddle = (r0.Width / 2);
			int nTop = (r0.Height - 16) / 2;
			int nLeft = (nMiddle - 16) / 2;

			Rectangle r1 = new Rectangle(nLeft, nTop, 16, 16);
			Rectangle r2 = new Rectangle(nMiddle+nLeft, nTop, 16, 16);
			//----------------------------

			//----------------------------
			// draw buttons
			Image img = leftRightImages.Images[1];
			if (img != null)
			{
				if (this.TabCount > 0)
				{
					Rectangle r3 = this.GetTabRect(0);
					if (r3.Left < TabControlArea.Left)
						g.DrawImage(img, r1);
					else
					{
						img = leftRightImages.Images[3];
						if (img != null)
							g.DrawImage(img, r1);
					}
				}
			}

			img = leftRightImages.Images[0];
			if (img != null)
			{
				if (this.TabCount > 0)
				{
					Rectangle r3 = this.GetTabRect(this.TabCount - 1);
					if (r3.Right > (TabControlArea.Width - r0.Width))
						g.DrawImage(img, r2);
					else
					{
						img = leftRightImages.Images[2];
						if (img != null)
							g.DrawImage(img, r2);
					}
				}
			}
			//----------------------------
		}

		protected override void OnCreateControl()
		{
			base.OnCreateControl();

			FindUpDown();
		}

		private void FlatTabControl_ControlAdded(object sender, ControlEventArgs e)
		{
			FindUpDown();
			UpdateUpDown();
		}

		private void FlatTabControl_ControlRemoved(object sender, ControlEventArgs e)
		{
			FindUpDown();
			UpdateUpDown();
		}

		private void FlatTabControl_SelectedIndexChanged(object sender, EventArgs e)
		{
			UpdateUpDown();
			Invalidate();	// we need to update border and background colors
		}

		private void FindUpDown()
		{
			bool bFound = false;

			// find the UpDown control
			IntPtr pWnd = Win32.GetWindow(this.Handle, Win32.GW_CHILD);
			
			while (pWnd != IntPtr.Zero)
			{
				//----------------------------
				// Get the window class name
				char[] className = new char[33];

				int length = Win32.GetClassName(pWnd, className, 32);

				string s = new string(className, 0, length);
				//----------------------------

				if (s == "msctls_updown32")
				{
					bFound = true;

					if (!bUpDown)
					{
						//----------------------------
						// Subclass it
						this.scUpDown = new SubClass(pWnd, true);
						this.scUpDown.SubClassedWndProc += new SubClass.SubClassWndProcEventHandler(scUpDown_SubClassedWndProc);
						//----------------------------

						bUpDown = true;
					}
					break;
				}
				
				pWnd = Win32.GetWindow(pWnd, Win32.GW_HWNDNEXT);
			}

			if ((!bFound) && (bUpDown))
				bUpDown = false;
		}

		private void UpdateUpDown()
		{
			if (bUpDown)
			{
				if (Win32.IsWindowVisible(scUpDown.Handle))
				{
					Rectangle rect = new Rectangle();

					Win32.GetClientRect(scUpDown.Handle, ref rect);
					Win32.InvalidateRect(scUpDown.Handle, ref rect, true);
				}
			}
		}

		#region scUpDown_SubClassedWndProc Event Handler

		private int scUpDown_SubClassedWndProc(ref Message m) 
		{
			switch (m.Msg)
			{
				case Win32.WM_PAINT:
				{
					//------------------------
					// redraw
					IntPtr hDC = Win32.GetWindowDC(scUpDown.Handle);
					Graphics g = Graphics.FromHdc(hDC);

					DrawIcons(g);

					g.Dispose();
					Win32.ReleaseDC(scUpDown.Handle, hDC);
					//------------------------

					// return 0 (processed)
					m.Result = IntPtr.Zero;

					//------------------------
					// validate current rect
					Rectangle rect = new Rectangle();

					Win32.GetClientRect(scUpDown.Handle, ref rect);
					Win32.ValidateRect(scUpDown.Handle, ref rect);
					//------------------------
				}
				return 1;
			}

			return 0;
		}
		#endregion

		#region Component Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			components = new System.ComponentModel.Container();
		}


		#endregion

		#region Properties
		
		[Editor(typeof(TabpageExCollectionEditor), typeof(UITypeEditor))]
		public new TabPageCollection TabPages
		{
			get
			{
				return base.TabPages;
			}
		}

		new public TabAlignment Alignment
		{
			get {return base.Alignment;}
			set {
				TabAlignment ta = value;
				if ((ta != TabAlignment.Top) && (ta != TabAlignment.Bottom))
					ta = TabAlignment.Top;
				
				base.Alignment = ta;}
		}

		[Browsable(false)]
		new public bool Multiline
		{
			get {return base.Multiline;}
			set {base.Multiline = false;}
		}

		[Browsable(true)]
        public Color myBackColor
        {
            get { return mBackColor; }
            set { mBackColor = value; this.Invalidate(); }
        }

        #endregion

        #region TabpageExCollectionEditor

        internal class TabpageExCollectionEditor : CollectionEditor
		{
			public TabpageExCollectionEditor(System.Type type): base(type)
			{
			}
            
			protected override Type CreateCollectionItemType()
			{
				return typeof(TabPage);
			}
		}
        
		#endregion
	}

	//#endregion
}
