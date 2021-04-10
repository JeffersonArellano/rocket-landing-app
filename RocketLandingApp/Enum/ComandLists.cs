using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace RocketLandingApp.Enum
{
    public enum ComandLists
    {
        CreateLandingZone,
        LandingZoneList,
        CreatePlatform,
        PlatformList,
        CreateRocket,
        RocketList,
        AskForLanding,
        DrawLandingArea,
        DrawPlatform
    }

    public enum PositionAnswer
    {
        [Description("ok for landing")]
        OkForLanding,
        [Description("out of platform")]
        OutOfPlatform,
        [Description("clash")]
        Clash
    }
}
