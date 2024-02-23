// Decompiled with JetBrains decompiler
// Type: FlexStringComparator.FlexStringComparator
// Assembly: FlexStringComparator, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 6C1B8F3C-257F-4FA4-B9C5-DC92161E05BC
// Assembly location: C:\KBs\Matika18u1\CSharpModel\Web\bin\FlexStringComparator.dll

using System;

namespace FlexStringComparator
{
  public class FlexStringComparator
  {
    public int LevenshteinDistance(string s, string t)
    {
      int length1 = s.Length;
      int length2 = t.Length;
      int[,] numArray = new int[length1 + 1, length2 + 1];
      int num1 = 0;
      if (length1 == 0)
        return length2;
      if (length2 == 0)
        return length1;
      int index1 = 0;
      while (index1 <= length1)
        numArray[index1, 0] = index1++;
      int index2 = 0;
      while (index2 <= length2)
        numArray[0, index2] = index2++;
      for (int index3 = 1; index3 <= length1; ++index3)
      {
        for (int index4 = 1; index4 <= length2; ++index4)
        {
          int num2 = (int) t[index4 - 1] == (int) s[index3 - 1] ? 0 : 1;
          numArray[index3, index4] = Math.Min(Math.Min(numArray[index3 - 1, index4] + 1, numArray[index3, index4 - 1] + 1), numArray[index3 - 1, index4 - 1] + num2);
          num1 = numArray[index3, index4];
        }
      }
      return num1;
    }
  }
}
