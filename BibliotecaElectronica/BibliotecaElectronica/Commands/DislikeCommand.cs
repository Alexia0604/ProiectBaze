using BibliotecaElectronica.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliotecaElectronica.Commands
{
    public class DislikeCommand : CommandBase
    {
        RecenzieModel _recenzie;
        public DislikeCommand(RecenzieModel recenzie)
        {
            _recenzie = recenzie;
        }

        public override void Execute(object parameter)
        {
            _recenzie.addDislike();
        }
    }
}
