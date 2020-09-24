using System;
using System.Collections.Generic;
using System.Text;

namespace AbbottFrameWork
{
    public class StatusInfo
    {
        public int errcode;
        public string errmesg;
        public string mesgargs;
        public int rowcount;
        public UserInfo uinfo;
        public StatusInfo()
        {
            Init();
        }
        public StatusInfo(UserInfo uinfo)
        {
            Init();
            this.uinfo = uinfo;
        }
        public void Init()
        {
            errcode = 0;
            rowcount = 0;
            errmesg = "";
            mesgargs = "";
        }
        [Serializable]
        public class UserInfo
        {
            public int userid;
            public short loglevel;
            public string username;
            public short transcategory = 2;
            public DateTime logEnabledTill = DateTime.MinValue;
            public UserInfo()
            {
            }
        }
    }
}
