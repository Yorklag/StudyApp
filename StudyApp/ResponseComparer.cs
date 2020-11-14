using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace StudyApp
{
    class ResponseComparer : System.Collections.IComparer
    {
        public int Compare(object x, object y)
        {
            return (new CaseInsensitiveComparer()).Compare(((PossibleResponses)x).Randnum, ((PossibleResponses)y).Randnum);
        }
    }
}
