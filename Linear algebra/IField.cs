using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinearAlgebra;

public interface IMathField
{
    IMathField Summ(IMathField left, IMathField right);

    IMathField Difference(IMathField left, IMathField right);

    IMathField Multiplication(IMathField left, IMathField right);

    IMathField Divide(IMathField left, IMathField right);

    bool EqualToZero(IMathField number);
}
