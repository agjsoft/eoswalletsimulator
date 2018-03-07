namespace EOSWallet
{
    public static class Define
    {
        public static int MyUserId = 50;

        public static string Convert(long val)
        {
            var chArr = val.ToString().ToCharArray();
            string ret = "";
            int cnt = 0;
            for (int i = chArr.Length - 1; i >= 0; i--, cnt++)
            {
                if (cnt == 8)
                    ret = "." + ret;
                ret = chArr[i] + ret;
            }
            int v = 9 - ret.Length;
            for (int i = 0; i < v; i++)
            {
                if (i == v - 1)
                    ret = "." + ret;
                ret = "0" + ret;
            }
            return ret;
        }
    }
}