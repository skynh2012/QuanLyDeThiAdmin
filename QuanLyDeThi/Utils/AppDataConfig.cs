using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuanLyDeThi.Models;

namespace QuanLyDeThi.Utils
{
   public class AppDataConfig
    {
        private static AppDataConfig instance = null;
        public static AppDataConfig Instance
        {
            get
            {
                if (instance == null)
                    instance = new AppDataConfig();
                return instance;
            }
        }

        public User userData { get; set; }
    }
}
