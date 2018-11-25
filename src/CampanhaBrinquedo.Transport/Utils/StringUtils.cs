using System;

namespace CampanhaBrinquedo.Transport.Utils
{
    public static class StringUtils
    {
        public static float CheckSimilarity(string word, string otherWord)
        {

            // Se as strings têm tamanho distinto, obtêm a similaridade de todas as
            // combinações em que tantos caracteres quanto a diferença entre elas são
            // inseridos na string de menor tamanho. Retorna a similaridade máxima
            // entre todas as combinações, descontando um percentual que representa
            // a diferença em número de caracteres.
            if(word.Length != otherWord.Length)
            {
                int iDiff = Math.Abs(word.Length - otherWord.Length);
                int iLen = Math.Max(word.Length, otherWord.Length);
                string sBigger, sSmaller, sAux;

                if(iLen == word.Length)
                {
                    sBigger = word;
                    sSmaller = otherWord;
                }
                else
                {
                    sBigger = otherWord;
                    sSmaller = word;
                }

                float fSim, fMaxSimilarity = float.MinValue;
                for(int i = 0; i <= sSmaller.Length; i++)
                {
                    sAux = sSmaller.Substring(0, i) + sBigger.Substring(i, i + iDiff) + sSmaller.Substring(i);
                    fSim = CheckSimilaritySameSize(sBigger, sAux);
                    if(fSim > fMaxSimilarity)
                    {
                        fMaxSimilarity = fSim;
                    }
                }
                return fMaxSimilarity - (1f * iDiff) / iLen;

                // Se as strings têm o mesmo tamanho, simplesmente compara-as caractere
                // a caractere. A similaridade advém das diferenças em cada posição.
            }
            else
            {
                return CheckSimilaritySameSize(word, otherWord);
            }
        }

        public static float CheckSimilaritySameSize(string word, string otherWord)
        {

            if(word.Length != otherWord.Length)
            {
                throw new Exception("Strings devem ter o mesmo tamanho!");
            }

            int iLen = word.Length;
            int iDiffs = 0;

            // Conta as diferenças entre as strings
            for(int i = 0; i < iLen; i++)
            {
                if(word[i] != otherWord[i])
                {
                    iDiffs++;
                }
            }

            // Calcula um percentual entre 0 e 1, sendo 0 completamente diferente e
            // 1 completamente igual
            return 1f - (float)iDiffs / iLen;
        }
    }
}

//try
//{
//    //Console.WriteLine($"'ABCD' vs 'ab' = {StringUtils.CheckSimilarity("ABCD", "ab")}");
//    //Console.WriteLine($"'cidade' vs 'cdade' = {StringUtils.CheckSimilarity("cidade", "cdade")}");
//    Console.WriteLine($"'cidade' vs 'ciDade' = {StringUtils.CheckSimilarity("cidade", "ciDade".ToLower())}");
//    Console.WriteLine($"'cidade' vs 'cdiade' = {StringUtils.CheckSimilarity("cidade", "cdiade".ToLower())}");
//    Console.WriteLine($"'cidade' vs 'edadic' = {StringUtils.CheckSimilarity("cidade", "edadic".ToLower())}");
//    Console.WriteLine($"'cidade' vs 'CIDADE' = {StringUtils.CheckSimilarity("cidade", "CIDADE".ToLower())}");
//    Console.WriteLine($"'cidade' vs 'CIdADE' = {StringUtils.CheckSimilarity("cidade", "CIdADE".ToLower())}");
//    Console.WriteLine($"'cidade' vs 'CdADE' = {StringUtils.CheckSimilarity("cidade", "CdADE".ToLower())}");
//}
//catch(Exception e)
//{
//    Console.WriteLine(e.Message);
//}
