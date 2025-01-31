using BibliotecaElectronica.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Channels;
using System.Text;
using System.Threading.Tasks;

namespace BibliotecaElectronica.Commands
{
    public class LikeCommand : CommandBase
    {
        RecenzieModel _recenzie;
        public LikeCommand(RecenzieModel recenzie)
        {
            _recenzie = recenzie;
        }

        public override void Execute(object parameter)
        {
            _recenzie.addLike();
        }
    }
}
