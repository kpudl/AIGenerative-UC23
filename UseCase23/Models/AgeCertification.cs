using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UseCase23.Models
{
    internal enum AgeCertification
    {
        G, 
        PG,
        [Description("PG-13")]
        PG13,
        R,
        [Description("NC-17")]
        NC17,
        U,
        [Description("U/A")]
        UA,
        A,
        S,
        AL,
        [Description("6")]
        N6 = 6,
        [Description("9")]
        N9 = 9,
        [Description("12")]
        N12 = 12,
        [Description("12A")]
        N12A,
        [Description("15")]
        N15 = 15,
        [Description("18")]
        N18 = 18,
        [Description("18R")]
        N18R, 
        R18,
        R21,
        M,
        [Description("MA15+")]
        MA15,
        R16,
        [Description("R18+")]
        R18Plus,
        X18,
        T,
        E,
        [Description("E10+")]
        E10Plus,
        EC,
        C,
        CA,
        GP,
        [Description("M/PG")]
        MPG,
        [Description("TV-Y")]
        TVY,
        [Description("TV-Y7")]
        TVY7,
        [Description("TV-G")]
        TVG,
        [Description("V-PG")]
        VPG,
        [Description("TV-14")]
        TV14,
        [Description("TV-MA")]
        TVMA
    }
}
