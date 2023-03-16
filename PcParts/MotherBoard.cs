using System;
using System.Collections.Generic;
using System.Text;

namespace PcParts
{
    internal class MotherBoard
    {
        public string vendor;
        public string model;
        public List<RamSlot> ram;

        public enum BOOT_STATE { OK, NO_CPU, NO_MEMORY}

        internal class PCIeSlot
        {
            public int version;
            public int lanes;

            public PCIeDevice device = new Audio();
        }

        public List<PCIeSlot> slots = new List<PCIeSlot>(); 

        public BOOT_STATE Boot()
        {
            return BOOT_STATE.OK;
        }

        public bool Bios()
        {
            return true;
        }
        
        public bool StartOS(int param)
        {
            return true;
        }
    }
}
