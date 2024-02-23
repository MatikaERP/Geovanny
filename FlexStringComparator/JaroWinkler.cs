// Decompiled with JetBrains decompiler
// Type: FlexStringComparator.JaroWinkler
// Assembly: FlexStringComparator, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 6C1B8F3C-257F-4FA4-B9C5-DC92161E05BC
// Assembly location: C:\KBs\Matika18u1\CSharpModel\Web\bin\FlexStringComparator.dll

using System;
using System.Text;

namespace FlexStringComparator
{
  public class JaroWinkler
  {
    private const double defaultMismatchScore = 0.0;
    private const double defaultMatchScore = 1.0;

    public static double RateSimilarity(string _firstWord, string _secondWord)
    {
      _firstWord = _firstWord.ToLower();
      _secondWord = _secondWord.ToLower();
      if (_firstWord == null || _secondWord == null)
        return 0.0;
      if (_firstWord == _secondWord)
        return 1.0;
      int separationDistance = Math.Min(_firstWord.Length, _secondWord.Length) / 2 + 1;
      StringBuilder commonCharacters1 = JaroWinkler.GetCommonCharacters(_firstWord, _secondWord, separationDistance);
      int length = commonCharacters1.Length;
      if (length == 0)
        return 0.0;
      StringBuilder commonCharacters2 = JaroWinkler.GetCommonCharacters(_secondWord, _firstWord, separationDistance);
      if (length != commonCharacters2.Length)
        return 0.0;
      int num1 = 0;
      for (int index = 0; index < length; ++index)
      {
        if ((int) commonCharacters1[index] != (int) commonCharacters2[index])
          ++num1;
      }
      int num2 = 0 + 1;
      int num3 = num1 / 2;
      return (double) length / (3.0 * (double) _firstWord.Length) + (double) length / (3.0 * (double) _secondWord.Length) + (double) (length - num3) / (3.0 * (double) length);
    }

    private static StringBuilder GetCommonCharacters(
      string firstWord,
      string secondWord,
      int separationDistance)
    {
      if (firstWord == null || secondWord == null)
        return (StringBuilder) null;
      StringBuilder commonCharacters = new StringBuilder(20);
      StringBuilder stringBuilder = new StringBuilder(secondWord);
      int length1 = firstWord.Length;
      int length2 = secondWord.Length;
      for (int index1 = 0; index1 < length1; ++index1)
      {
        char ch = firstWord[index1];
        bool flag = false;
        for (int index2 = Math.Max(0, index1 - separationDistance); !flag && index2 < Math.Min(index1 + separationDistance, length2); ++index2)
        {
          if ((int) stringBuilder[index2] == (int) ch)
          {
            flag = true;
            commonCharacters.Append(ch);
            stringBuilder[index2] = '#';
          }
        }
      }
      return commonCharacters;
    }
  }
}
