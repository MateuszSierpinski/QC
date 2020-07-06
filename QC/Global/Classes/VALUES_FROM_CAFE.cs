
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Windows.Forms;

namespace QC
{
    public class VALUES_FROM_CAFE
    {  
        
        public static bool Validation = false;
        public static bool Ncoa18 = false;
        public static bool Quad_Seeds = false;       
        public static bool Ncoa48 = false;
        public static bool Dsf = false;       
        public static bool Pick_Up = false;
        public static bool Merge_Purge = false;

        public static string Cafe = "";
        public static string TitleCode = "";
        public static string JobNumber = "";
        public static string MailClass = "";
        public static string Ncoa18_Path = "";
        public static string Dsf_Path = "";
        public static string PresortType = "";
        public static string IMB = "";
        public static string OutputTypeLaser = "";
        public static string PrintLocationLaser = "";
        public static string OutputTypeInkjet = "";
        public static string PrintLocationInkjet = "";

        public static RichTextBox richText = new RichTextBox();

        public static List<string> CAFES = new List<string>();
        public static List<string> MEDIA_ID_LIST = new List<string>();
        public static List<string> FLOW_NAMES = new List<string>();
        public static List<string> IMB_SERVICE = new List<string>();
        public static List<string> MAIL_OWNER_MIDS = new List<string>();
        public static List<string> BOOK_IDS = new List<string>();
        public static List<string> MPU_IDS = new List<string>();
        public static List<string> PROCESSORS = new List<string>();

        public static Stopwatch Timer = new Stopwatch();
        public static TimeSpan Processing_Time = new TimeSpan();
        public static void dodaj()
        {
            //MEDIA_ID_LIST.Add("1082966E_F1");
            //MEDIA_ID_LIST.Add("1091109E_F1");
            //MEDIA_ID_LIST.Add("1093262E_F1");
            //MEDIA_ID_LIST.Add("1093267E_F10");
            //MEDIA_ID_LIST.Add("1093267E_F4");
            //MEDIA_ID_LIST.Add("1093267E_F7");
        }
    }
}
