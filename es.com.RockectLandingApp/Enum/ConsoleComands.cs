using System.ComponentModel;

namespace es.com.RockectLandingApp.Enum
{
    public enum ConsoleComands
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
        [Description("Ask For Position")]
        AskForPosition,
        [Description("Draw Landing Area")]
        DrawLandingArea,
        [Description("Draw Platform")]
        DrawPlatform,
        [Description("Request Position")]
        RequestPosition,
    }

}
