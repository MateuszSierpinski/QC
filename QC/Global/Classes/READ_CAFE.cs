using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace QC
{
    public class READ_CAFE
    {
        public void Read_cafe(string WebPageText, string Cafe)
        {
            

            VALUES_FROM_CAFE.Cafe = Cafe;

            #region Main

            String TitleCode = "";
            Regex re4 = new Regex("id=\"TitleCode\" type=\"hidden\" value=\"(.*)\"");
            Match match4 = re4.Match(WebPageText);
            if (match4.Success)
            {
                TitleCode = match4.Value;
                TitleCode = TitleCode.Replace("id=\"TitleCode\" type=\"hidden\" value=\"", "").Replace("\"", "");
            }
            VALUES_FROM_CAFE.TitleCode = TitleCode;

            String JobNumber = "";
            Regex re3 = new Regex("id=\"JobNumber\" type=\"hidden\" value=\"(.*)\"");
            Match match3 = re3.Match(WebPageText);
            if (match3.Success)
            {
                JobNumber = match3.Value;
                JobNumber = JobNumber.Replace("id=\"JobNumber\" type=\"hidden\" value=\"", "").Replace("\"", "");
            }
            VALUES_FROM_CAFE.JobNumber = "Job Number: " + JobNumber;

            String Mail_Owner_MID = "";
            List<string> MAIL_OWNER_MIDS = new List<string>();
            Regex REG_MID = new Regex("id=\"MidOnMailPiece\" style=\"display: none;\" type=\"text\" value=\"(.*)\">");
            Match match_MID = REG_MID.Match(WebPageText);
            while (match_MID.Success)
            {

                Mail_Owner_MID = match_MID.Value;
                Mail_Owner_MID = Mail_Owner_MID.Replace("id=\"MidOnMailPiece\" style=\"display: none;\" type=\"text\" value=\"", "")
                                               .Replace("><span class=\"text-block undefined\">", "")
                                               .Replace("<span></span></span></li>","").Replace("\"", "").Trim(); 
                if (MAIL_OWNER_MIDS.Count == 0)
                {
                    MAIL_OWNER_MIDS.Add(Mail_Owner_MID);
                }

                for (int i = 0; i < MAIL_OWNER_MIDS.Count; i++)
                {
                    if (Mail_Owner_MID != MAIL_OWNER_MIDS[i])
                    {
                        MAIL_OWNER_MIDS.Add(Mail_Owner_MID);
                    }
                }
                match_MID = match_MID.NextMatch();
            }

            String IMB_Service_Type = "";
            List<string> IMB_SERVICE_TYPES = new List<string>();
            Regex REG_IMB = new Regex("id=\"ImbServiceTypeId\" style=\"display: none;\" type=\"text\" maxlength=\"3\" value=\"(.*)\">");
            Match match_IMB = REG_IMB.Match(WebPageText);
            while (match_IMB.Success)
            {
                IMB_Service_Type = match_IMB.Value;
                IMB_Service_Type = IMB_Service_Type.Replace("id=\"ImbServiceTypeId\" style=\"display: none;\" type=\"text\" maxlength=\"3\" value=\"", "")
                                                   .Replace("><span class=\"text-block undefined\">", "")
                                                   .Replace("<span></span></span></li>", "").Replace("\"", "").Trim(); ;
                if (IMB_SERVICE_TYPES.Count == 0)
                {
                    IMB_SERVICE_TYPES.Add(IMB_Service_Type);
                }

                for (int i = 0; i < IMB_SERVICE_TYPES.Count; i++)
                {
                    if (IMB_Service_Type != IMB_SERVICE_TYPES[i])
                    {
                        IMB_SERVICE_TYPES.Add(IMB_Service_Type);
                    }
                }
                match_IMB = match_IMB.NextMatch();
            }

            String SerialStart = "";
            List<string> SERIAL_START = new List<string>();
            Regex REG_START = new Regex("id=\"ImbSerialStart\" style=\"display: none;\" type=\"text\" value=\"(.*)\">");
            Match match_START = REG_START.Match(WebPageText);
            while (match_START.Success)
            {
                SerialStart = match_START.Value;
                SerialStart = SerialStart.Replace("id=\"ImbSerialStart\" style=\"display: none;\" type=\"text\" value=\"", "")
                                         .Replace("><span class=\"text-block upper-case-entry\">", "")
                                         .Replace("<span></span></span></li>", "").Replace("\"", "").Trim(); ;
                if (SERIAL_START.Count == 0)
                {
                    SERIAL_START.Add(SerialStart);
                }
                for (int i = 0; i < SERIAL_START.Count; i++)
                {
                    if (SerialStart != SERIAL_START[i])
                    {
                        SERIAL_START.Add(SerialStart);
                    }
                }
                match_START = match_START.NextMatch();
            }

            VALUES_FROM_CAFE.IMB_SERVICE = IMB_SERVICE_TYPES;
            VALUES_FROM_CAFE.MAIL_OWNER_MIDS = MAIL_OWNER_MIDS;

            if (MAIL_OWNER_MIDS.Count == 0)
            {
                VALUES_FROM_CAFE.IMB = "YOU HAVE NO IMB";
            }

            if (MAIL_OWNER_MIDS.Count == 1 && IMB_SERVICE_TYPES.Count == 1 && SERIAL_START.Count == 1)
            {
                string MID = MAIL_OWNER_MIDS[0];
                string IMB = IMB_SERVICE_TYPES[0];
                string SERIAL = SERIAL_START[0];

                VALUES_FROM_CAFE.IMB = "IMB: " + SERIAL + " - " + IMB + " - " + MID;
            }
            
            if (MAIL_OWNER_MIDS.Count > 1)
            {
                VALUES_FROM_CAFE.IMB = "YOU HAVE TWO IMB VERSIONS";
            }

            String MailClass = "";
            Regex REG_CLASS1 = new Regex("<option selected=\"selected\" value=\"51\">Standard</option>");
            Regex REG_CLASS2 = new Regex("<option selected=\"selected\" value=\"49\">First Class</option>");
            Match match_CLASS1 = REG_CLASS1.Match(WebPageText);
            Match match_CLASS2 = REG_CLASS2.Match(WebPageText);
            if (match_CLASS1.Success)
            {
                MailClass = "Standard";
            }
            if (match_CLASS2.Success)
            {
                MailClass = "First Class";
            }

            VALUES_FROM_CAFE.MailClass = MailClass;

            String PresortType = "";
            Regex REG_PRESORT1 = new Regex("<option selected=\"selected\" value=\"191\">Manual Upload</option>");
            Regex REG_PRESORT2 = new Regex("<option selected=\"selected\" value=\"190\">Commingle</option>");
            Regex REG_PRESORT3 = new Regex("<option selected=\"selected\" value=\"350\">QMO</option>");
            Regex REG_PRESORT4 = new Regex("<option selected=\"selected\" value=\"189\">Auto Upload</option>");
            Match match_PRESORT1 = REG_PRESORT1.Match(WebPageText);
            Match match_PRESORT2 = REG_PRESORT2.Match(WebPageText);
            Match match_PRESORT3 = REG_PRESORT3.Match(WebPageText);
            Match match_PRESORT4 = REG_PRESORT4.Match(WebPageText);
            if (match_PRESORT1.Success)
            {
                PresortType = "Manual Upload: Dropship";
            }
            if (match_PRESORT2.Success)
            {
                PresortType = "Commingle";
            }
            if (match_PRESORT3.Success)
            {
                PresortType = "QMO";
            }
            if (match_PRESORT4.Success)
            {
                PresortType = "Auto Upload: Dropship";
            }

            VALUES_FROM_CAFE.PresortType = PresortType;

            #endregion

            #region Services

            Regex REG_VALIDATION = new Regex("id=\"Cass\" type=\"checkbox\" checked=\"checked\" value=\"true\"");
            Match match_VALIDATION = REG_VALIDATION.Match(WebPageText);
            if (match_VALIDATION.Success)
            {
                VALUES_FROM_CAFE.Validation = true;
            }

            Regex REG_IS_NCOA = new Regex("id=\"Ncoa18Month\" type=\"checkbox\" checked=\"checked\" value=\"true\"");
            Match match_IS_NCOA = REG_IS_NCOA.Match(WebPageText);
            if (match_IS_NCOA.Success)
            {
                VALUES_FROM_CAFE.Ncoa18 = true;
            }
            if (VALUES_FROM_CAFE.Ncoa18 == true)
            {
                String NCOA_PAF = "";
                Regex REG_PAF = new Regex("<span class=\"paf-text-block\" id=\"NewestNcoaPafId\" name=\"NewestNcoaPafId\">(.*)</span>");
                Match match_PAF = REG_PAF.Match(WebPageText);
                if (match4.Success)
                {
                    NCOA_PAF = match_PAF.Value;
                    NCOA_PAF = NCOA_PAF.Replace("<span class=\"paf-text-block\" id=\"NewestNcoaPafId\" name=\"NewestNcoaPafId\">", "").Replace("</span>", "");
                }
                VALUES_FROM_CAFE.Ncoa18_Path = "PAF: " + NCOA_PAF;
            }

            Regex REG_IS_NCOA_48 = new Regex("id=\"Ncoa48Month\" type=\"checkbox\" checked=\"checked\" value=\"true\"");
            Match match_IS_NCOA_48 = REG_IS_NCOA_48.Match(WebPageText);
            if (match_IS_NCOA_48.Success)
            {
                VALUES_FROM_CAFE.Ncoa48 = true;
            }

            Regex REG_DSF = new Regex("id=\"Dsf\" type=\"checkbox\" checked=\"checked\" value=\"true\"");
            Match match_DSF = REG_DSF.Match(WebPageText);
            if (match_DSF.Success)
            {
                VALUES_FROM_CAFE.Dsf = true;
            }

            if (VALUES_FROM_CAFE.Dsf == true)
            {
                String DSF_PAF = "";
                Regex REG_PAF = new Regex("<span class=\"paf-text-block\" id=\"NewestDsfPafId\" name=\"NewestDsfPafId\">(.*)</span>");
                Match match_PAF = REG_DSF.Match(WebPageText);
                if (match4.Success)
                {
                    DSF_PAF = match_PAF.Value;
                    DSF_PAF = DSF_PAF.Replace("<span class=\"paf-text-block\" id=\"NewestDsfPafId\" name=\"NewestDsfPafId\">", "").Replace("</span>", "");
                }
                VALUES_FROM_CAFE.Dsf_Path = "PAF: " + DSF_PAF;
            }


            Regex REG_MP = new Regex("id=\"MergePurgeTypeId\" style=\"display: none;\"><option value=\"\"></option><option selected=\"selected\"");
            Match match_MP = REG_MP.Match(WebPageText);
            if (match_MP.Success)
            {
                VALUES_FROM_CAFE.Merge_Purge = true;
            }

            ////"id=\"SuppressionsNeeded\" name=\"SuppressionsNeeded\" type=\"checkbox\" value=\"true\"

            //Regex REG_SUPP = new Regex("id=\"SuppressionsNeeded\" name=\"SuppressionsNeeded\" type=\"checkbox\" value=\"true\"");
            //Match match_SUPP = REG_SUPP.Match(res);
            //if (match_SUPP.Success)
            //{
            //    form.checkBox6.Checked = true;
            //}

            #endregion

            #region Output
            
    //Pick Up Design

            Regex REG_PICK_UP = new Regex("id=\"IndicatePickUpDesign\" type=\"checkbox\" checked=\"checked\"");
            Match match_PICK_UP = REG_PICK_UP.Match(WebPageText);
            if (match_PICK_UP.Success)
            {
                VALUES_FROM_CAFE.Pick_Up = true;
            }

    //LASER

            string OutputTypeLaser = "";

            Regex REG_LASER_OUTPUT = new Regex("id=\"LaserDigitalPress\" type=\"checkbox\" checked=\"checked\" value=\"true\">");
            Match match_LASER_OUTPUT = REG_LASER_OUTPUT.Match(WebPageText);
            if (match_LASER_OUTPUT.Success) OutputTypeLaser = "Output Type: " + "Digital Roll to Roll/Sheet";

            if(OutputTypeLaser != "") VALUES_FROM_CAFE.OutputTypeLaser = OutputTypeLaser;

            string PrintLocationLaser = "";
            Regex REG_LASER1 = new Regex("<option selected=\"selected\" value=\"351\">Westampton</option>");
            Regex REG_LASER2 = new Regex("<option selected=\"selected\" value=\"184\">Pewaukee</option>");
            Regex REG_LASER3 = new Regex("<option selected=\"selected\" value=\"185\">West Allis</option>");
            Regex REG_LASER4 = new Regex("<option selected=\"selected\" value=\"450\">HICO</option>");
            Regex REG_LASER5 = new Regex("<option selected=\"selected\" value=\"451\">USGPO</option>");
            Regex REG_LASER6 = new Regex("<option selected=\"selected\" value=\"403\">Woburn</option>");

            Match match_LASER1 = REG_LASER1.Match(WebPageText);
            Match match_LASER2 = REG_LASER2.Match(WebPageText);
            Match match_LASER3 = REG_LASER3.Match(WebPageText);
            Match match_LASER4 = REG_LASER4.Match(WebPageText);
            Match match_LASER5 = REG_LASER5.Match(WebPageText);
            Match match_LASER6 = REG_LASER6.Match(WebPageText);

            if (match_LASER1.Success) PrintLocationLaser = "Westampton";           
            if (match_LASER2.Success) PrintLocationLaser = "Pewaukee";
            if (match_LASER3.Success) PrintLocationLaser = "West Allis";
            if (match_LASER4.Success) PrintLocationLaser = "HICO";
            if (match_LASER5.Success) PrintLocationLaser = "USGPO";
            if (match_LASER6.Success) PrintLocationLaser = "Woburn";


            VALUES_FROM_CAFE.PrintLocationLaser = PrintLocationLaser;

    //INKJET

            string PrintLocationInkjet = "";
            string OutputTypeInkjet = "";

            // Inkjet Driver File

            Regex REG_INKJET_OUTPUT = new Regex("id=\"InkjetDriverFile\" type=\"checkbox\" checked=\"checked\" value=\"true\">");
            Match match_INKJET_OUTPUT = REG_INKJET_OUTPUT.Match(WebPageText);
            if (match_INKJET_OUTPUT.Success) OutputTypeInkjet = "Output Type: " + "InlinePress / Convert";

            if (OutputTypeInkjet != "") VALUES_FROM_CAFE.OutputTypeInkjet = OutputTypeInkjet;

            Regex REG_INKJET_1 = new Regex("<option selected=\"selected\" value=\"560\">Chalfont</option>");
            Regex REG_INKJET_2 = new Regex("<option selected=\"selected\" value=\"561\">Effingham</option>");
            Regex REG_INKJET_3 = new Regex("<option selected=\"selected\" value=\"452\">HICO</option>");
            Regex REG_INKJET_4 = new Regex("<option selected=\"selected\" value=\"453\">USGPO</option>");

            Match match_INKJET_1 = REG_INKJET_1.Match(WebPageText);
            Match match_INKJET_2 = REG_INKJET_2.Match(WebPageText);
            Match match_INKJET_3 = REG_INKJET_3.Match(WebPageText);
            Match match_INKJET_4 = REG_INKJET_4.Match(WebPageText);

            if (match_INKJET_1.Success) PrintLocationInkjet = "Chalfont";
            if (match_INKJET_2.Success) PrintLocationInkjet = "Effingham";
            if (match_INKJET_3.Success) PrintLocationInkjet = "HICO";
            if (match_INKJET_4.Success) PrintLocationInkjet = "USGPO";


            // Offline Finishing IJ
            
            Regex REG_FINISHING_OUTPUT = new Regex("id=\"OfflineFinishingIJ\" type=\"checkbox\" checked=\"checked\" value=\"true\">");
            Match match_FINISHING_OUTPUT = REG_FINISHING_OUTPUT.Match(WebPageText);
            if (match_FINISHING_OUTPUT.Success) OutputTypeInkjet = "Output Type: " + "Offline Finishing IJ";

            if (OutputTypeInkjet != "") VALUES_FROM_CAFE.OutputTypeInkjet = OutputTypeInkjet;

            Regex REG_INKJET_OFF_1 = new Regex("<option selected=\"selected\" value=\"551\">Effingham</option>");
            Regex REG_INKJET_OFF_2 = new Regex("<option selected=\"selected\" value=\"552\">Pewaukee</option>");
            Regex REG_INKJET_OFF_3 = new Regex("<option selected=\"selected\" value=\"553\">Westampton</option>");
            Regex REG_INKJET_OFF_4 = new Regex("<option selected=\"selected\" value=\"554\">Woburn</option>");
            Regex REG_INKJET_OFF_5 = new Regex("<option selected=\"selected\" value=\"556\">HICO</option>");
            Regex REG_INKJET_OFF_6 = new Regex("<option selected=\"selected\" value=\"557\">USGPO</option>");
            Regex REG_INKJET_OFF_7 = new Regex("<option selected=\"selected\" value=\"558\">CSV - Burlington</option>");
            Regex REG_INKJET_OFF_8 = new Regex("<option selected=\"selected\" value=\"559\">FMS - Burlington</option>");
            Regex REG_INKJET_OFF_9 = new Regex("<option selected=\"selected\" value=\"454\">FMS - Hartford</option>");
            Regex REG_INKJET_OFF_10 = new Regex("<option selected=\"selected\" value=\"455\">FMS - Lomira</option>");
            Regex REG_INKJET_OFF_11 = new Regex("<option selected=\"selected\" value=\"456\">FMS - Oklahoma City</option>");
            Regex REG_INKJET_OFF_12 = new Regex("<option selected=\"selected\" value=\"457\">FMS - Saratoga</option>");
            Regex REG_INKJET_OFF_13 = new Regex("<option selected=\"selected\" value=\"458\">FMS - Sussex</option>");
            Regex REG_INKJET_OFF_14 = new Regex("<option selected=\"selected\" value=\"459\">FMS - The Rock</option>");
            Regex REG_INKJET_OFF_15 = new Regex("<option selected=\"selected\" value=\"460\">FMS - West Allis</option>");

            Match match_INKJET_OFF_1 = REG_INKJET_OFF_1.Match(WebPageText);
            Match match_INKJET_OFF_2 = REG_INKJET_OFF_2.Match(WebPageText);
            Match match_INKJET_OFF_3 = REG_INKJET_OFF_3.Match(WebPageText);
            Match match_INKJET_OFF_4 = REG_INKJET_OFF_4.Match(WebPageText);
            Match match_INKJET_OFF_5 = REG_INKJET_OFF_5.Match(WebPageText);
            Match match_INKJET_OFF_6 = REG_INKJET_OFF_6.Match(WebPageText);
            Match match_INKJET_OFF_7 = REG_INKJET_OFF_7.Match(WebPageText);
            Match match_INKJET_OFF_8 = REG_INKJET_OFF_8.Match(WebPageText);
            Match match_INKJET_OFF_9 = REG_INKJET_OFF_9.Match(WebPageText);
            Match match_INKJET_OFF_10 = REG_INKJET_OFF_10.Match(WebPageText);
            Match match_INKJET_OFF_11 = REG_INKJET_OFF_11.Match(WebPageText);
            Match match_INKJET_OFF_12 = REG_INKJET_OFF_12.Match(WebPageText);
            Match match_INKJET_OFF_13 = REG_INKJET_OFF_13.Match(WebPageText);
            Match match_INKJET_OFF_14 = REG_INKJET_OFF_14.Match(WebPageText);
            Match match_INKJET_OFF_15 = REG_INKJET_OFF_15.Match(WebPageText);

            if (match_INKJET_OFF_1.Success) PrintLocationInkjet = "Effingham";
            if (match_INKJET_OFF_2.Success) PrintLocationInkjet = "Pewaukee";
            if (match_INKJET_OFF_3.Success) PrintLocationInkjet = "Westampton";
            if (match_INKJET_OFF_4.Success) PrintLocationInkjet = "Woburn";
            if (match_INKJET_OFF_5.Success) PrintLocationInkjet = "HICO";
            if (match_INKJET_OFF_6.Success) PrintLocationInkjet = "USGPO";
            if (match_INKJET_OFF_7.Success) PrintLocationInkjet = "CSV - Burlington";
            if (match_INKJET_OFF_8.Success) PrintLocationInkjet = "FMS - Burlington";
            if (match_INKJET_OFF_9.Success) PrintLocationInkjet = "FMS - Hartford";
            if (match_INKJET_OFF_10.Success) PrintLocationInkjet = "FMS - Lomira";
            if (match_INKJET_OFF_11.Success) PrintLocationInkjet = "FMS - Oklahoma City";
            if (match_INKJET_OFF_12.Success) PrintLocationInkjet = "FMS - Saratoga";
            if (match_INKJET_OFF_13.Success) PrintLocationInkjet = "FMS - Sussex";
            if (match_INKJET_OFF_14.Success) PrintLocationInkjet = "FMS - The Rock";
            if (match_INKJET_OFF_15.Success) PrintLocationInkjet = "FMS - West Allis";


            // Finishing Driver File Location

            Regex REG_DRIVER_OUTPUT = new Regex("id=\"FinishingDriverFile\" type=\"checkbox\" checked=\"checked\" value=\"true\">");
            Match match_DRIVER_OUTPUT = REG_DRIVER_OUTPUT.Match(WebPageText);
            if (match_DRIVER_OUTPUT.Success) OutputTypeInkjet = "Output Type: " + "Offline Finishing IJ";

            if (OutputTypeInkjet != "") VALUES_FROM_CAFE.OutputTypeInkjet = OutputTypeInkjet;

            Regex REG_INKJET_DRIVER_1 = new Regex("<option selected=\"selected\" value=\"570\">Pewaukee</option>");
            Regex REG_INKJET_DRIVER_2 = new Regex("<option selected=\"selected\" value=\"571\">Westampton</option>");
            Regex REG_INKJET_DRIVER_3 = new Regex("<option selected=\"selected\" value=\"573\">HICO</option>");
            Regex REG_INKJET_DRIVER_4 = new Regex("<option selected=\"selected\" value=\"574\">FMS - Hartford</option>");
            Regex REG_INKJET_DRIVER_5 = new Regex("<option selected=\"selected\" value=\"575\">FMS - Lomira</option>");
            Regex REG_INKJET_DRIVER_6 = new Regex("<option selected=\"selected\" value=\"576\">FMS - Oklahoma City</option>");
            Regex REG_INKJET_DRIVER_7 = new Regex("<option selected=\"selected\" value=\"577\">FMS - Saratoga</option>");
            Regex REG_INKJET_DRIVER_8 = new Regex("<option selected=\"selected\" value=\"578\">FMS - Sussex</option>");
            Regex REG_INKJET_DRIVER_9 = new Regex("<option selected=\"selected\" value=\"579\">FMS - The Rock</option>");
            Regex REG_INKJET_DRIVER_10 = new Regex("<option selected=\"selected\" value=\"580\">FMS - West Allis</option>");

            Match match_INKJET_DRIVER_1 = REG_INKJET_DRIVER_1.Match(WebPageText);
            Match match_INKJET_DRIVER_2 = REG_INKJET_DRIVER_2.Match(WebPageText);
            Match match_INKJET_DRIVER_3 = REG_INKJET_DRIVER_3.Match(WebPageText);
            Match match_INKJET_DRIVER_4 = REG_INKJET_DRIVER_4.Match(WebPageText);
            Match match_INKJET_DRIVER_5 = REG_INKJET_DRIVER_5.Match(WebPageText);
            Match match_INKJET_DRIVER_6 = REG_INKJET_DRIVER_6.Match(WebPageText);
            Match match_INKJET_DRIVER_7 = REG_INKJET_DRIVER_7.Match(WebPageText);
            Match match_INKJET_DRIVER_8 = REG_INKJET_DRIVER_8.Match(WebPageText);
            Match match_INKJET_DRIVER_9 = REG_INKJET_DRIVER_9.Match(WebPageText);
            Match match_INKJET_DRIVER_10 = REG_INKJET_DRIVER_10.Match(WebPageText);

            if (match_INKJET_DRIVER_1.Success) PrintLocationInkjet = "Pewaukee";
            if (match_INKJET_DRIVER_2.Success) PrintLocationInkjet = "Westampton";
            if (match_INKJET_DRIVER_3.Success) PrintLocationInkjet = "HICO";
            if (match_INKJET_DRIVER_4.Success) PrintLocationInkjet = "FMS - Hartford";
            if (match_INKJET_DRIVER_5.Success) PrintLocationInkjet = "FMS - Lomira";
            if (match_INKJET_DRIVER_6.Success) PrintLocationInkjet = "FMS - Oklahoma City";
            if (match_INKJET_DRIVER_7.Success) PrintLocationInkjet = "FMS - Saratoga";
            if (match_INKJET_DRIVER_8.Success) PrintLocationInkjet = "FMS - Sussex";
            if (match_INKJET_DRIVER_9.Success) PrintLocationInkjet = "FMS - The Rock";
            if (match_INKJET_DRIVER_10.Success) PrintLocationInkjet = "FMS - West Allis";


            VALUES_FROM_CAFE.PrintLocationInkjet = PrintLocationInkjet;

            #endregion

            #region MEDIA ID's & VERSIONS

            String Mail_Version = "";
            List<string> MAIL_VERSIONS = new List<string>();
            Regex re6 = new Regex("<td class=\" sorting-1\">(.*)</td>\n + <td>(.*)</td>\n + <td>(.*)</td>\n + \n + <td>(.*)</td>\n +"
                                  +" <td>(.*)</td>\n + <td>(.*)</td>\n + <td>(.*)</td>\n + <td>(.*)</td>\n +"
                                  + "<td>(.*)</td>\n + <td>(.*)</td>\n + <td>(.*)</td>\n + <td>(.*)</td>");                                  
            Match match6 = re6.Match(WebPageText);
            while (match6.Success)
            {
                Mail_Version = match6.Value;
                Mail_Version = Mail_Version.Replace("<td class=\" sorting-1\">", "")
                                           .Replace("<td>", "").Replace("</td>", "|").Replace(" ", "");
                MAIL_VERSIONS.Add(Mail_Version);
                match6 = match6.NextMatch();
            }



            VALUES_FROM_CAFE.richText.Clear();

            VALUES_FROM_CAFE.richText.AppendText(/*"There is : "*/ + MAIL_VERSIONS.Count() + " Version/s\n\n");
            foreach (var MV in MAIL_VERSIONS)
            {
                var MV1 = MV.Split('|');
                VALUES_FROM_CAFE.richText.AppendText("Name:  " + MV1[0].Trim() + "\n");
                VALUES_FROM_CAFE.richText.AppendText("Description:  " + MV1[1].Trim() + "\n");
                if (MV1[3].Trim() == "")
                {
                    VALUES_FROM_CAFE.richText.AppendText("Book ID:  " + MV1[4].Trim() + "\n");
                    VALUES_FROM_CAFE.BOOK_IDS.Add(MV1[4].Trim());
                }
                else
                {
                    VALUES_FROM_CAFE.richText.AppendText("Book ID:  " + MV1[3].Trim() + "\n");
                    VALUES_FROM_CAFE.BOOK_IDS.Add(MV1[3].Trim());
                }
                if (MV1[3].Trim() == "")
                {
                    if (MV1[5].Trim() == "Y")
                    {
                        VALUES_FROM_CAFE.Quad_Seeds = true;
                        VALUES_FROM_CAFE.richText.AppendText("MPU ID:  " + MV1[6].Trim() + "\n" + "\n");
                        VALUES_FROM_CAFE.MPU_IDS.Add(MV1[6].Trim());
                    }
                    else
                    {
                        VALUES_FROM_CAFE.richText.AppendText("\n");
                    }
                }
                else
                {
                    if (MV1[4].Trim() == "Y")
                    {
                        VALUES_FROM_CAFE.Quad_Seeds = true;
                        VALUES_FROM_CAFE.richText.AppendText("MPU ID:  " + MV1[5].Trim() + "\n" + "\n");
                        VALUES_FROM_CAFE.MPU_IDS.Add(MV1[5].Trim());
                    }
                    else
                    {
                        VALUES_FROM_CAFE.richText.AppendText("\n");
                    }
                }

            }
            
            
            
            String Media_Id = "";
            List<string> Media_IDs = new List<string>();
            Regex re7 = new Regex("Disk Farm (.*)</td><td>(.*)</td>");
            Match match7 = re7.Match(WebPageText);
            if (match7.Success)
            {
                Media_Id = match7.Value;
                Media_Id = Media_Id.Replace("Disk Farm (Pending)", "\n").Replace("<td class=\" sorting-1\">", "")
                                            .Replace("<tr class=\"even\">", "").Replace("<tr class=\"odd\">", "")
                                            .Replace("<td>", "").Replace("</tr>","").Replace("</td>","|");

                Media_IDs = Media_Id.Split('\n').ToList();
                Media_IDs.RemoveAt(0);
            }

            foreach (var m in Media_IDs)
            {
                var Ids = m.Split('|').ToList();

                VALUES_FROM_CAFE.MEDIA_ID_LIST.Add(Ids[1]);
            }
            #endregion
        }

    }
}
