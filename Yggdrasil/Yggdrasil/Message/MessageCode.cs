using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yggdrasil.Message
{
    public enum MessageCode : byte
    {
        Connection = 0x00,
        Disconnection = 0x01,
        Publish = 0x02,
        Subscribe = 0x03
    }
}
