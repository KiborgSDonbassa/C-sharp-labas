public class Logger
    {
        private string path;
        public enum logType{
             Trace,
             Debug,
             Info,
             Warn,
             Error,
             Fatal
        }

        public Logger()
        {
            path = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location) + "/log";
            Directory.CreateDirectory(path);
        }
        public void Log(logType a, string message, Exception ex = null)
        {
            using (StreamWriter writer = new StreamWriter(path + "/logg.txt", true))
            {
                if (ex == null)
                {
                    writer.WriteLine(DateTime.Now + "|" + a.ToString().ToUpper() + "|" + "User name: " +
                                     System.Environment.UserName + "|Message: \"" + message + "\"|");
                }

                if (ex != null)
                {
                    writer.WriteLine(DateTime.Now + "|" + a.ToString().ToUpper() + "|" + "User name: " +
                                     System.Environment.UserName + "|Message: \"" + message + "\"|Error: " + ex.Message);
                }
            }
        }
    }
