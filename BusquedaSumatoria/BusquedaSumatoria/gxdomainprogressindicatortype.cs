using GeneXus.Application;
using GeneXus.Utils;
using System.Collections;
using System.Runtime.CompilerServices;

namespace BusquedaSumatoria
{
    public class gxdomainprogressindicatortype
    {
        private static Hashtable domain = new Hashtable();
        private static Hashtable domainMap;

        static gxdomainprogressindicatortype()
        {
            gxdomainprogressindicatortype.domain[(object)"I"] = (object)"Indeterminate";
            gxdomainprogressindicatortype.domain[(object)"D"] = (object)"Determinate";
        }

        public static string getDescription(IGxContext context, string key)
        {
            string key1 = key == null ? "" : StringUtil.Trim(key);
            return gxdomainprogressindicatortype.domain[(object)key1] == null ? "" : (string)gxdomainprogressindicatortype.domain[(object)key1];
        }

        public static GxSimpleCollection<string> getValues()
        {
            GxSimpleCollection<string> values = new GxSimpleCollection<string>();
            ArrayList arrayList = new ArrayList(gxdomainprogressindicatortype.domain.Keys);
            arrayList.Sort();
            foreach (string o in arrayList)
                values.Add((object)o);
            return values;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        public static string getValue(string key)
        {
            if (gxdomainprogressindicatortype.domainMap == null)
            {
                gxdomainprogressindicatortype.domainMap = new Hashtable();
                gxdomainprogressindicatortype.domainMap[(object)"Indeterminate"] = (object)"I";
                gxdomainprogressindicatortype.domainMap[(object)"Determinate"] = (object)"D";
            }
            return (string)gxdomainprogressindicatortype.domainMap[(object)key];
        }
    }
}
