using System;
using System.Collections.Generic;
using System.Text;

namespace PcParts
{
    internal abstract class PCIeDevice
    {

    }

    internal class Expansion : PCIeDevice
    {

    }
    internal class Audio : Expansion
    {

    }
    internal class Connectivity : Expansion
    {

    }
}
