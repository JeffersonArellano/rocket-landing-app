using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace es.com.RockectApp.Enum
{
    public enum ComandLists
    {
        [Description("Create Landing Area")]
        CreateLandingArea,
        [Description("Landing Area List")]
        LandingAreaList,
        [Description("Create Platform")]
        CreatePlatform,
        [Description("Platform List")]
        PlatformList,
        [Description("Create Rocket")]
        CreateRocket,
        [Description("Rocket List")]
        RocketList,
        [Description("Ask For Landing")]
        AskForLanding,
        [Description("Draw Landing Area")]
        DrawLandingArea,
        [Description("Draw Platform")]
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
