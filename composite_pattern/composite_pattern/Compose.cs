using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace composite_pattern
{
    internal class Compose
    {
        class Program
        {
            static void Main()
            {
                Paragraph p1 = new Paragraph("перый параграф");
                Paragraph p2 = new Paragraph("и второй");

                Section section1 = new Section("ВВЕДЕНИЕ");
                section1.Add(p1);
                section1.Add(p2);

                Paragraph p3 = new Paragraph("парагр. второй секции");
                Section section2 = new Section("ОСН. ЧАСТЬ");
                section2.Add(p3);

                Document document = new Document();
                document.Add(section1);
                document.Add(section2);

                document.Display(0);
            }
        }
    }
}
