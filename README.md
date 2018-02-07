# FollowTarget.ScreenSpaceUI
UI follows target in scene around the canvas. Support aspect ratio, fixed ratio, and spherized clamp

returns Vector3 to be used for a UI gameobject in canvas.

    /// <param name="worldSpace_Tr">target</param>
    /// <param name="offSetWorldSpace">offset pos.</param>
    /// <param name="clampEdge">gives extra space to clamp edge of screen. 0-1 percent.</param>
    /// <param name="wrapAroundScreen">if target goes behind cam, it'll still stay on the edge.</param>
    /// <param name="ignoreAspectRatio">force clamps to ignore aspectRatio.</param>
    /// <param name="spherize">clamps into a sphere instead of boxed screen. 'Uses clampEdge.x' only.</param>
