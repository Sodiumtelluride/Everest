﻿#pragma warning disable CS0626 // Method, operator, or accessor is marked external and has no attributes on it
#pragma warning disable CS0649 // Field is never assigned to, and will always have its default value
#pragma warning disable CS0169 // The field is never used

using Celeste.Mod;
using Microsoft.Xna.Framework;
using Monocle;
using MonoMod;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Celeste {
    class patch_OuiChapterSelectIcon : OuiChapterSelectIcon {

        // We're effectively in OuiChapterSelectIcon, but still need to "expose" private fields to our mod.
        private bool hidden;
        public bool IsHidden => hidden;

        private bool selected;
        public bool IsSelected => selected;

        public patch_OuiChapterSelectIcon(int area, MTexture front, MTexture back)
            : base(area, front, back) {
            // no-op. MonoMod ignores this - we only need this to make the compiler shut up.
        }

    }
    public static class OuiChapterSelectIconExt {

        // Mods can't access patch_ classes directly.
        // We thus expose any new members through extensions.

        public static bool GetIsHidden(this OuiChapterSelectIcon self)
            => ((patch_OuiChapterSelectIcon) self).IsHidden;

        public static bool GetIsSelected(this OuiChapterSelectIcon self)
            => ((patch_OuiChapterSelectIcon) self).IsSelected;

    }
}
