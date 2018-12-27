using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication1
{
    // בנאי לבדיקת תקינות ת.ז
    class id
    {
        private string tz;

        public id(string tz)
        {
            this.tz = tz;
        }

        public bool numberid()
        {
            if (tz.Length == 9)
                return true;
            return false;
        }

        public bool iddigit()
        {
            if (numberid())
            {
                char[] a = new char[9];
                int i;
                a = tz.ToCharArray();
                for (i = 0; i < a.Length; i++)
                    if (a[i] < '0' || a[i] > '9')
                        return false;
                return true;
            }
            return false;
        }

        public bool goodid()
        {
            if (iddigit())
            {
                int sum = 0;
                int[] a = new int[9];
                for (int i = 0; i < tz.Length; i++)
                    a[i] = int.Parse(tz.Substring(i, 1).ToString());

                for (int i = 0; i < a.Length - 1; i++)
                {
                    if (i % 2 == 1)
                    {
                        a[i] = a[i] * 2;
                        if (a[i] > 9)
                            a[i] = a[i] - 9;
                    }
                }
                for (int i = 0; i < a.Length; i++)
                {

                    sum += a[i];

                }
                if (sum % 10 != 0)
                    return false;
                return true;
            }
            return false;

        }
    }
}
