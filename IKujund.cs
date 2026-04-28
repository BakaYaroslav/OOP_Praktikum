using System;
using System.Collections.Generic;
using System.Text;

namespace OOP_Praktikum
{
    public interface IKujund
    {
        // Liides kirjeldab AINULT meetodite allkirju. Sisu siia ei kirjutata.
        // Iga klass, mis seda liidest rakendab, PEAB need meetodid ise looma.
        double ArvutaPindala();
        double ArvutaÜmbermõõt();
    }
}
