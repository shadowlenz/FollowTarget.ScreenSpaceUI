# FollowTarget.ScreenSpaceUI
UI follows target in scene around the canvas. Support aspect ratio, fixed ratio, and spherized clamp

returns Vector3 to be used for a UI gameobject in canvas.

    /// <param name="worldSpace_Tr : target"></param>
    /// <param name="offSetWorldSpace : offset pos"></param>
    /// <param name="clampSpace : gives extra space to clamp edge of screen"></param>
    /// <param name="wrapAroundScreen : if target goes behind cam, it'll still stay on the edge"></param>
    /// <param name="IgnoreaspectRatio : forces to clamps to ignore aspectRatio"></param>
    /// <param name="spherize : clamps into a sphere instead of boxed screen. Uses clampEdge.x only"></param>
