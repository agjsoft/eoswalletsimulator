using System;

namespace EOSWallet
{
    public static class Define
    {
        public static int MyUserId = 50;
        private static string[] FirstWord = new string[] { "큰", "작은", "늦은", "늙은", "파란", "빨간", "적은",
            "짧은", "긴", "노란", "검은", "재미있는", "재미없는", "밝은", "어두운", "얇은", "두꺼운", "젊은",
            "빠른", "능숙한", "어수룩한", "매력있는", "매력없는", "착한", "나쁜"};
        private static string[] SecondWord = new string[] { "하늘", "돈", "사람", "컴퓨터", "서리", "이오스", "비트코인",
            "스트라티스", "라이트코인", "리플", "모네로", "인터넷", "스마트폰", "모니터", "대한민국", "스페인",
            "미국", "일본", "러시아", "중국", "태국", "영국", "서울", "런던", "도쿄", "뉴욕", "워싱턴", "오사카",
            "북경", "남경", "상하이", "파리", "프랑스", "독일", "베를린", "마드리드", "바다", "육지", "무덤",
            "언어", "직업", "자전거", "자동차", "데이터", "블록원", "댄라이머" };
        private static Random Rn = new Random();

        public static string GetRandomName()
        {
            return FirstWord[Rn.Next(0, FirstWord.Length - 1)] + SecondWord[Rn.Next(0, SecondWord.Length - 1)];
        }

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