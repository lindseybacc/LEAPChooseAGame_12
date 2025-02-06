using System;
using System.Collections.Generic;
using System.IO.IsolatedStorage;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Word_Search
{
    public class Word
    {
        private string text;
        private string startPoint;
        private string endPoint;

        public Word(string word, string start, string end)
        {
            text = word; 
            startPoint = start;
            endPoint = end;
        }

        public int getLength()
        {
            return text.Length;
        }

        public bool isFound(string startPoint, string endPoint)
        {
            if (startPoint == this.startPoint && endPoint == this.endPoint)
            {
                return true;
            }
            else
            {
                return false;   
            }
      
        }


    }
}
