﻿/* 
 * Copyright (C) 2020, Carlos H.M.S. <carlos_judo@hotmail.com>
 * This file is part of OpenBound.
 * OpenBound is free software: you can redistribute it and/or modify it under the terms of the GNU General Public License
 * as published by the Free Software Foundation, either version 3 of the License, or(at your option) any later version.
 * 
 * OpenBound is distributed in the hope that it will be useful, but WITHOUT ANY WARRANTY; without even the implied warranty
 * of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.See the GNU General Public License for more details.
 * 
 * You should have received a copy of the GNU General Public License along with OpenBound. If not, see http://www.gnu.org/licenses/.
 */

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using OpenBound.Common;
using Openbound_Network_Object_Library.Entity;
using System.Collections.Generic;
using System.Linq;

namespace OpenBound.GameComponents.Animation
{
    public enum MobileFlipbookState
    {
        Stand, //Normal
        StandLowHealth, //WNormal

        Moving, //Move
        MovingLowHealth, //WMove

        UnableToMove, //Unmove

        Emotion1, //Emotion1
        Emotion2, // 1/25 (no need)

        BeingDamaged1, //fDamage
        BeingDamaged2, //bDamage
        BeingShocked, //Shock
        BeingFrozen, //ICE

        ChargingS1, //bFire1 CHARGING t1
        ShootingS1, //Fire1

        ChargingS2, //bFire2 CHARGING t2
        ShootingS2, //Fire2

        ChargingSS, //bsFire CHARGING SS SHOT
        ShootingSS, //sFire

        UsingItem, //Item

        DepletingShield, //Shield

        Dead, //Dead

        Falling, //Drop

        All, //SFX
    }

    public class MobileFlipbook
    {
        static readonly Dictionary<MobileType, Dictionary<MobileFlipbookState, AnimationInstance>> MobileStatePresets = new Dictionary<MobileType, Dictionary<MobileFlipbookState, AnimationInstance>>()
        {
            {
                MobileType.Random,
                new Dictionary<MobileFlipbookState, AnimationInstance>()
                {
                    { MobileFlipbookState.Stand, new AnimationInstance() { StartingFrame =   0, EndingFrame =  11, TimePerFrame = 1/20f } },
                }
            },
            #region Armor
            {
                MobileType.Armor,
                new Dictionary<MobileFlipbookState, AnimationInstance>()
                {
                    { MobileFlipbookState.Stand,           new AnimationInstance() { StartingFrame =   0, EndingFrame =  20, TimePerFrame = 1/20f } },
                    { MobileFlipbookState.StandLowHealth,  new AnimationInstance() { StartingFrame = 151, EndingFrame = 171, TimePerFrame = 1/18f } },

                    { MobileFlipbookState.Moving,          new AnimationInstance() { StartingFrame =  21, EndingFrame =  39, TimePerFrame = 1/17f } },
                    { MobileFlipbookState.MovingLowHealth, new AnimationInstance() { StartingFrame = 169, EndingFrame = 189, TimePerFrame = 1/17f } },

                    { MobileFlipbookState.UnableToMove,   new AnimationInstance() { StartingFrame = 191, EndingFrame = 210, TimePerFrame = 1/19f } },

                    { MobileFlipbookState.Emotion1,        new AnimationInstance() { StartingFrame = 349, EndingFrame = 378, TimePerFrame = 1/29f } },
                    { MobileFlipbookState.Emotion2,        new AnimationInstance() { StartingFrame = 312, EndingFrame = 349, TimePerFrame = 1/29f } },

                    { MobileFlipbookState.BeingDamaged1,   new AnimationInstance() { StartingFrame = 378, EndingFrame = 405, TimePerFrame = 1/24f } },
                    { MobileFlipbookState.BeingDamaged2,   new AnimationInstance() { StartingFrame = 404, EndingFrame = 430, TimePerFrame = 1/24f } },
                    { MobileFlipbookState.BeingShocked,    new AnimationInstance() { StartingFrame =  49, EndingFrame =  69, TimePerFrame = 1/19f } },
                    { MobileFlipbookState.BeingFrozen,     new AnimationInstance() { StartingFrame = 216, EndingFrame = 216, TimePerFrame = 1f } },

                    { MobileFlipbookState.ChargingS1,      new AnimationInstance() { StartingFrame =  91, EndingFrame = 110, TimePerFrame = 1/19f } },
                    { MobileFlipbookState.ShootingS1,      new AnimationInstance() { StartingFrame =  40, EndingFrame =  49, TimePerFrame = 1/19f } },

                    { MobileFlipbookState.ChargingS2,      new AnimationInstance() { StartingFrame =  91, EndingFrame = 110, TimePerFrame = 1/19f } },
                    { MobileFlipbookState.ShootingS2,      new AnimationInstance() { StartingFrame = 291, EndingFrame = 318, TimePerFrame = 1/26f } },

                    { MobileFlipbookState.ChargingSS,      new AnimationInstance() { StartingFrame =  91, EndingFrame = 110, TimePerFrame = 1/14f } },
                    { MobileFlipbookState.ShootingSS,      new AnimationInstance() { StartingFrame = 429, EndingFrame = 454, TimePerFrame = 1/20f } },

                    { MobileFlipbookState.UsingItem,       new AnimationInstance() { StartingFrame = 230, EndingFrame = 250, TimePerFrame = 1/19f } },

                    { MobileFlipbookState.Dead,            new AnimationInstance() { StartingFrame =  71, EndingFrame =  89, TimePerFrame = 1/19f } },

                    { MobileFlipbookState.Falling,         new AnimationInstance() { StartingFrame = 131, EndingFrame = 149, TimePerFrame = 1/18f } },

                    { MobileFlipbookState.All,             new AnimationInstance() { StartingFrame =   0, EndingFrame = 456, TimePerFrame = 1/18f } },
                }
            },
            #endregion
            #region Bigfoot
            {
                MobileType.Bigfoot,
                new Dictionary<MobileFlipbookState, AnimationInstance>()
                {
                    { MobileFlipbookState.Stand,           new AnimationInstance() { StartingFrame =   0, EndingFrame =  19, TimePerFrame = 1/20f } },
                    { MobileFlipbookState.StandLowHealth,  new AnimationInstance() { StartingFrame =  45, EndingFrame =  64, TimePerFrame = 1/18f } },
                    { MobileFlipbookState.Moving,          new AnimationInstance() { StartingFrame =  20, EndingFrame =  44, TimePerFrame = 1/17f } },
                    { MobileFlipbookState.MovingLowHealth, new AnimationInstance() { StartingFrame =  65, EndingFrame = 104, TimePerFrame = 1/17f } },
                    //
                    { MobileFlipbookState.UnableToMove,   new AnimationInstance() { StartingFrame = 105, EndingFrame = 124, TimePerFrame = 1/19f } },

                    { MobileFlipbookState.Emotion1,        new AnimationInstance() { StartingFrame = 354, EndingFrame = 393, TimePerFrame = 1/29f } },
                    { MobileFlipbookState.Emotion2,        new AnimationInstance() { StartingFrame = 354, EndingFrame = 393, TimePerFrame = 1/29f } },

                    { MobileFlipbookState.BeingDamaged1,   new AnimationInstance() { StartingFrame = 394, EndingFrame = 418, TimePerFrame = 1/24f } },
                    { MobileFlipbookState.BeingDamaged2,   new AnimationInstance() { StartingFrame = 419, EndingFrame = 441, TimePerFrame = 1/24f } },
                    { MobileFlipbookState.BeingShocked,    new AnimationInstance() { StartingFrame = 147, EndingFrame = 166, TimePerFrame = 1/19f } },
                    { MobileFlipbookState.BeingFrozen,     new AnimationInstance() { StartingFrame = 301, EndingFrame = 301, TimePerFrame = 0f } },

                    { MobileFlipbookState.ChargingS1,      new AnimationInstance() { StartingFrame = 212, EndingFrame = 233, TimePerFrame = 1/19f } },
                    { MobileFlipbookState.ShootingS1,      new AnimationInstance() { StartingFrame = 125, EndingFrame = 146, TimePerFrame = 1/19f } },

                    { MobileFlipbookState.ChargingS2,      new AnimationInstance() { StartingFrame = 254, EndingFrame = 273, TimePerFrame = 1/19f } },
                    { MobileFlipbookState.ShootingS2,      new AnimationInstance() { StartingFrame = 125, EndingFrame = 146, TimePerFrame = 1/19f } },

                    { MobileFlipbookState.ChargingSS,      new AnimationInstance() { StartingFrame = 254, EndingFrame = 273, TimePerFrame = 1/14f } },
                    { MobileFlipbookState.ShootingSS,      new AnimationInstance() { StartingFrame = 274, EndingFrame = 293, TimePerFrame = 1/20f } },

                    { MobileFlipbookState.UsingItem,       new AnimationInstance() { StartingFrame = 234, EndingFrame = 253, TimePerFrame = 1/19f } },

                    { MobileFlipbookState.Dead,            new AnimationInstance() { StartingFrame = 202, EndingFrame = 211, TimePerFrame = 1/19f } },

                    { MobileFlipbookState.Falling,         new AnimationInstance() { StartingFrame = 187, EndingFrame = 201, TimePerFrame = 1/18f } },

                    { MobileFlipbookState.All,             new AnimationInstance() { StartingFrame =   0, EndingFrame = 469, TimePerFrame = 1/18f } },
                }
            },
            #endregion
            #region Dragon
            {
                MobileType.Dragon,
                new Dictionary<MobileFlipbookState, AnimationInstance>()
                {
                    { MobileFlipbookState.Stand,           new AnimationInstance() { StartingFrame =   0, EndingFrame =  19, TimePerFrame = 1/20f } },
                    { MobileFlipbookState.StandLowHealth,  new AnimationInstance() { StartingFrame =  40, EndingFrame =  59, TimePerFrame = 1/18f } },
                    { MobileFlipbookState.Moving,          new AnimationInstance() { StartingFrame =  20, EndingFrame =  39, TimePerFrame = 1/17f } },
                    { MobileFlipbookState.MovingLowHealth, new AnimationInstance() { StartingFrame =  60, EndingFrame =  79, TimePerFrame = 1/17f } },

                    { MobileFlipbookState.UnableToMove,   new AnimationInstance() { StartingFrame =  80, EndingFrame =  99, TimePerFrame = 1/19f } },

                    { MobileFlipbookState.Emotion1,        new AnimationInstance() { StartingFrame = 278, EndingFrame = 297, TimePerFrame = 1/29f } },
                    { MobileFlipbookState.Emotion2,        new AnimationInstance() { StartingFrame = 278, EndingFrame = 297, TimePerFrame = 1/29f } },

                    { MobileFlipbookState.BeingDamaged1,   new AnimationInstance() { StartingFrame = 479, EndingFrame = 503, TimePerFrame = 1/24f } },
                    { MobileFlipbookState.BeingDamaged2,   new AnimationInstance() { StartingFrame = 504, EndingFrame = 528, TimePerFrame = 1/24f } },
                    { MobileFlipbookState.BeingShocked,    new AnimationInstance() { StartingFrame = 388, EndingFrame = 407, TimePerFrame = 1/19f } },
                    { MobileFlipbookState.BeingFrozen,     new AnimationInstance() { StartingFrame = 448, EndingFrame = 448, TimePerFrame = 0f } },

                    { MobileFlipbookState.ChargingS1,      new AnimationInstance() { StartingFrame = 328, EndingFrame = 342, TimePerFrame = 1/19f } },
                    { MobileFlipbookState.ShootingS1,      new AnimationInstance() { StartingFrame = 100, EndingFrame = 114, TimePerFrame = 1/19f } },

                    { MobileFlipbookState.ChargingS2,      new AnimationInstance() { StartingFrame = 343, EndingFrame = 357, TimePerFrame = 1/19f } },
                    { MobileFlipbookState.ShootingS2,      new AnimationInstance() { StartingFrame = 115, EndingFrame = 134, TimePerFrame = 1/21f } },

                    { MobileFlipbookState.ChargingSS,      new AnimationInstance() { StartingFrame = 449, EndingFrame = 463, TimePerFrame = 1/14f } },
                    { MobileFlipbookState.ShootingSS,      new AnimationInstance() { StartingFrame = 464, EndingFrame = 478, TimePerFrame = 1/20f } },

                    { MobileFlipbookState.UsingItem,       new AnimationInstance() { StartingFrame = 141, EndingFrame = 160, TimePerFrame = 1/19f } },

                    { MobileFlipbookState.Dead,            new AnimationInstance() { StartingFrame = 263, EndingFrame = 277, TimePerFrame = 1/19f } },

                    { MobileFlipbookState.Falling,         new AnimationInstance() { StartingFrame = 248, EndingFrame = 262, TimePerFrame = 1/18f } },

                    { MobileFlipbookState.All,             new AnimationInstance() { StartingFrame =   0, EndingFrame = 469, TimePerFrame = 1/18f } },
                }
            },
            #endregion
            #region Mage
            {
                MobileType.Mage,
                new Dictionary<MobileFlipbookState, AnimationInstance>()
                {
                    { MobileFlipbookState.Stand,           new AnimationInstance() { StartingFrame =   0, EndingFrame =  19, TimePerFrame = 1/20f } },
                    { MobileFlipbookState.StandLowHealth,  new AnimationInstance() { StartingFrame =  40, EndingFrame =  59, TimePerFrame = 1/18f } },
                    { MobileFlipbookState.Moving,          new AnimationInstance() { StartingFrame =  20, EndingFrame =  39, TimePerFrame = 1/17f } },
                    { MobileFlipbookState.MovingLowHealth, new AnimationInstance() { StartingFrame =  60, EndingFrame =  79, TimePerFrame = 1/17f } },

                    { MobileFlipbookState.UnableToMove,   new AnimationInstance() { StartingFrame =  80, EndingFrame =  99, TimePerFrame = 1/19f } },

                    { MobileFlipbookState.Emotion1,        new AnimationInstance() { StartingFrame = 322, EndingFrame = 340, TimePerFrame = 1/29f } },
                    { MobileFlipbookState.Emotion2,        new AnimationInstance() { StartingFrame = 322, EndingFrame = 340, TimePerFrame = 1/29f } },

                    { MobileFlipbookState.BeingDamaged1,   new AnimationInstance() { StartingFrame = 341, EndingFrame = 365, TimePerFrame = 1/24f } },
                    { MobileFlipbookState.BeingDamaged2,   new AnimationInstance() { StartingFrame = 366, EndingFrame = 390, TimePerFrame = 1/24f } },
                    { MobileFlipbookState.BeingShocked,    new AnimationInstance() { StartingFrame = 120, EndingFrame = 139, TimePerFrame = 1/19f } },
                    { MobileFlipbookState.BeingFrozen,     new AnimationInstance() { StartingFrame = 167, EndingFrame = 167, TimePerFrame = 0f } },

                    { MobileFlipbookState.ChargingS1,      new AnimationInstance() { StartingFrame = 204, EndingFrame = 222, TimePerFrame = 1/19f } },
                    { MobileFlipbookState.ShootingS1,      new AnimationInstance() { StartingFrame = 100, EndingFrame = 119, TimePerFrame = 1/19f } },

                    { MobileFlipbookState.ChargingS2,      new AnimationInstance() { StartingFrame = 303, EndingFrame = 321, TimePerFrame = 1/19f } },
                    { MobileFlipbookState.ShootingS2,      new AnimationInstance() { StartingFrame = 100, EndingFrame = 119, TimePerFrame = 1/21f } },

                    { MobileFlipbookState.ChargingSS,      new AnimationInstance() { StartingFrame = 391, EndingFrame = 409, TimePerFrame = 1/14f } },
                    { MobileFlipbookState.ShootingSS,      new AnimationInstance() { StartingFrame = 100, EndingFrame = 119, TimePerFrame = 1/20f } },

                    { MobileFlipbookState.UsingItem,       new AnimationInstance() { StartingFrame = 243, EndingFrame = 262, TimePerFrame = 1/19f } },

                    { MobileFlipbookState.Dead,            new AnimationInstance() { StartingFrame = 179, EndingFrame = 203, TimePerFrame = 1/19f } },

                    { MobileFlipbookState.Falling,         new AnimationInstance() { StartingFrame = 160, EndingFrame = 178, TimePerFrame = 1/18f } },

                    { MobileFlipbookState.All,             new AnimationInstance() { StartingFrame =   0, EndingFrame = 411, TimePerFrame = 1/18f } },
                }
            },
            #endregion
            #region Ice
            {
                MobileType.Ice,
                new Dictionary<MobileFlipbookState, AnimationInstance>()
                {
                    { MobileFlipbookState.Stand,           new AnimationInstance() { StartingFrame =   0, EndingFrame =  19, TimePerFrame = 1/20f } },
                    { MobileFlipbookState.StandLowHealth,  new AnimationInstance() { StartingFrame =  35, EndingFrame =  54, TimePerFrame = 1/18f } },
                    { MobileFlipbookState.Moving,          new AnimationInstance() { StartingFrame =  20, EndingFrame =  34, TimePerFrame = 1/20f } },
                    { MobileFlipbookState.MovingLowHealth, new AnimationInstance() { StartingFrame =  55, EndingFrame =  74, TimePerFrame = 1/18f } },

                    { MobileFlipbookState.UnableToMove,   new AnimationInstance() { StartingFrame =  75, EndingFrame =  94, TimePerFrame = 1/19f } },

                    { MobileFlipbookState.Emotion1,        new AnimationInstance() { StartingFrame = 203, EndingFrame = 222, TimePerFrame = 1/29f } },
                    { MobileFlipbookState.Emotion2,        new AnimationInstance() { StartingFrame = 203, EndingFrame = 222, TimePerFrame = 1/29f } },

                    { MobileFlipbookState.BeingDamaged1,   new AnimationInstance() { StartingFrame = 363, EndingFrame = 387, TimePerFrame = 1/24f } },
                    { MobileFlipbookState.BeingDamaged2,   new AnimationInstance() { StartingFrame = 388, EndingFrame = 412, TimePerFrame = 1/24f } },
                    { MobileFlipbookState.BeingShocked,    new AnimationInstance() { StartingFrame = 273, EndingFrame = 292, TimePerFrame = 1/19f } },
                    { MobileFlipbookState.BeingFrozen,     new AnimationInstance() { StartingFrame = 135, EndingFrame = 135, TimePerFrame = 0f } },

                    { MobileFlipbookState.ChargingS1,      new AnimationInstance() { StartingFrame = 223, EndingFrame = 237, TimePerFrame = 1/19f } },
                    { MobileFlipbookState.ShootingS1,      new AnimationInstance() { StartingFrame =  95, EndingFrame = 114, TimePerFrame = 1/19f } },

                    { MobileFlipbookState.ChargingS2,      new AnimationInstance() { StartingFrame = 238, EndingFrame = 252, TimePerFrame = 1/19f } },
                    { MobileFlipbookState.ShootingS2,      new AnimationInstance() { StartingFrame = 115, EndingFrame = 129, TimePerFrame = 1/21f } },

                    { MobileFlipbookState.ChargingSS,      new AnimationInstance() { StartingFrame = 313, EndingFrame = 327, TimePerFrame = 1/14f } },
                    { MobileFlipbookState.ShootingSS,      new AnimationInstance() { StartingFrame = 328, EndingFrame = 347, TimePerFrame = 1/20f } },

                    { MobileFlipbookState.UsingItem,       new AnimationInstance() { StartingFrame = 253, EndingFrame = 272, TimePerFrame = 1/19f } },

                    { MobileFlipbookState.Dead,            new AnimationInstance() { StartingFrame = 190, EndingFrame = 202, TimePerFrame = 1/19f } },

                    { MobileFlipbookState.Falling,         new AnimationInstance() { StartingFrame = 293, EndingFrame = 312, TimePerFrame = 1/18f } },

                    { MobileFlipbookState.All,             new AnimationInstance() { StartingFrame =   0, EndingFrame = 469, TimePerFrame = 1/18f } },
                }
            },
            #endregion
            #region Knight
            {
                MobileType.Knight,
                new Dictionary<MobileFlipbookState, AnimationInstance>()
                {
                    { MobileFlipbookState.Stand,           new AnimationInstance() { StartingFrame =   0, EndingFrame =  19, TimePerFrame = 1/20f } },
                    { MobileFlipbookState.StandLowHealth,  new AnimationInstance() { StartingFrame = 182, EndingFrame = 199, TimePerFrame = 1/18f } },

                    { MobileFlipbookState.Moving,          new AnimationInstance() { StartingFrame =  20, EndingFrame =  37, TimePerFrame = 1/17f } },
                    { MobileFlipbookState.MovingLowHealth, new AnimationInstance() { StartingFrame = 200, EndingFrame = 217, TimePerFrame = 1/17f } },

                    { MobileFlipbookState.UnableToMove,   new AnimationInstance() { StartingFrame = 103, EndingFrame = 122, TimePerFrame = 1/19f } },

                    { MobileFlipbookState.Emotion1,        new AnimationInstance() { StartingFrame = 218, EndingFrame = 247, TimePerFrame = 1/29f } },
                    { MobileFlipbookState.Emotion2,        new AnimationInstance() { StartingFrame = 218, EndingFrame = 247, TimePerFrame = 1/29f } },

                    { MobileFlipbookState.BeingDamaged1,   new AnimationInstance() { StartingFrame = 308, EndingFrame = 332, TimePerFrame = 1/24f } },
                    { MobileFlipbookState.BeingDamaged2,   new AnimationInstance() { StartingFrame = 333, EndingFrame = 357, TimePerFrame = 1/24f } },
                    { MobileFlipbookState.BeingShocked,    new AnimationInstance() { StartingFrame = 288, EndingFrame = 307, TimePerFrame = 1/19f } },
                    { MobileFlipbookState.BeingFrozen,     new AnimationInstance() { StartingFrame = 216, EndingFrame = 216, TimePerFrame = 1f } },

                    { MobileFlipbookState.ChargingS1,      new AnimationInstance() { StartingFrame =  68, EndingFrame =  87, TimePerFrame = 1/19f } },
                    { MobileFlipbookState.ShootingS1,      new AnimationInstance() { StartingFrame =  88, EndingFrame = 102, TimePerFrame = 1/14f } },

                    { MobileFlipbookState.ChargingS2,      new AnimationInstance() { StartingFrame =  38, EndingFrame =  52, TimePerFrame = 1/14f } },
                    { MobileFlipbookState.ShootingS2,      new AnimationInstance() { StartingFrame =  53, EndingFrame =  67, TimePerFrame = 1/14f } },

                    { MobileFlipbookState.ChargingSS,      new AnimationInstance() { StartingFrame = 358, EndingFrame = 372, TimePerFrame = 1/14f } },
                    { MobileFlipbookState.ShootingSS,      new AnimationInstance() { StartingFrame =  53, EndingFrame =  67, TimePerFrame = 1/14f } },

                    { MobileFlipbookState.UsingItem,       new AnimationInstance() { StartingFrame = 248, EndingFrame = 267, TimePerFrame = 1/19f } },

                    { MobileFlipbookState.Dead,            new AnimationInstance() { StartingFrame = 268, EndingFrame = 287, TimePerFrame = 1/19f } },

                    { MobileFlipbookState.Falling,         new AnimationInstance() { StartingFrame = 123, EndingFrame = 141, TimePerFrame = 1/18f } },

                    { MobileFlipbookState.All,             new AnimationInstance() { StartingFrame =   0, EndingFrame = 373, TimePerFrame = 1/18f } },
                }
            },
            #endregion
            #region Turtle
            {
                MobileType.Turtle,
                new Dictionary<MobileFlipbookState, AnimationInstance>()
                {
                    { MobileFlipbookState.Stand,           new AnimationInstance() { StartingFrame =   0, EndingFrame =  19, TimePerFrame = 1/20f } },
                    { MobileFlipbookState.StandLowHealth,  new AnimationInstance() { StartingFrame =  42, EndingFrame =  61, TimePerFrame = 1/18f } },

                    { MobileFlipbookState.Moving,          new AnimationInstance() { StartingFrame =  20, EndingFrame =  41, TimePerFrame = 1/17f } },
                    { MobileFlipbookState.MovingLowHealth, new AnimationInstance() { StartingFrame =  62, EndingFrame =  83, TimePerFrame = 1/17f } },

                    { MobileFlipbookState.UnableToMove,   new AnimationInstance() { StartingFrame =   84, EndingFrame = 103, TimePerFrame = 1/19f } },

                    { MobileFlipbookState.Emotion1,        new AnimationInstance() { StartingFrame = 309, EndingFrame = 333, TimePerFrame = 1/29f } },
                    { MobileFlipbookState.Emotion2,        new AnimationInstance() { StartingFrame = 309, EndingFrame = 333, TimePerFrame = 1/29f } },

                    { MobileFlipbookState.BeingDamaged1,   new AnimationInstance() { StartingFrame = 374, EndingFrame = 398, TimePerFrame = 1/24f } },
                    { MobileFlipbookState.BeingDamaged2,   new AnimationInstance() { StartingFrame = 399, EndingFrame = 423, TimePerFrame = 1/24f } },
                    { MobileFlipbookState.BeingShocked,    new AnimationInstance() { StartingFrame = 249, EndingFrame = 268, TimePerFrame = 1/19f } },
                    { MobileFlipbookState.BeingFrozen,     new AnimationInstance() { StartingFrame = 171, EndingFrame = 171, TimePerFrame = 1f } },

                    { MobileFlipbookState.ChargingS1,      new AnimationInstance() { StartingFrame = 189, EndingFrame = 208, TimePerFrame = 1/19f } },
                    { MobileFlipbookState.ShootingS1,      new AnimationInstance() { StartingFrame = 104, EndingFrame = 123, TimePerFrame = 1/19f } },

                    { MobileFlipbookState.ChargingS2,      new AnimationInstance() { StartingFrame = 334, EndingFrame = 353, TimePerFrame = 1/19f } },
                    { MobileFlipbookState.ShootingS2,      new AnimationInstance() { StartingFrame = 354, EndingFrame = 373, TimePerFrame = 1/26f } },

                    { MobileFlipbookState.ChargingSS,      new AnimationInstance() { StartingFrame = 424, EndingFrame = 443, TimePerFrame = 1/14f } },
                    { MobileFlipbookState.ShootingSS,      new AnimationInstance() { StartingFrame = 444, EndingFrame = 463, TimePerFrame = 1/20f } },

                    { MobileFlipbookState.UsingItem,       new AnimationInstance() { StartingFrame = 269, EndingFrame = 288, TimePerFrame = 1/19f } },

                    { MobileFlipbookState.Dead,            new AnimationInstance() { StartingFrame = 289, EndingFrame = 308, TimePerFrame = 1/19f } },

                    { MobileFlipbookState.Falling,         new AnimationInstance() { StartingFrame = 164, EndingFrame = 183, TimePerFrame = 1/18f } },

                    { MobileFlipbookState.All,             new AnimationInstance() { StartingFrame =   0, EndingFrame = 464, TimePerFrame = 1/18f } },
                }
            },
            #endregion
        };

        public MobileFlipbookState State { get; private set; }

        public Flipbook Flipbook;

        public Dictionary<MobileFlipbookState, AnimationInstance> StatePresets;

        public Vector2 Position
        {
            get => Flipbook.Position;
            set => Flipbook.Position = value;
        }

        public float Rotation
        {
            get => Flipbook.Rotation;
            set => Flipbook.Rotation = value;
        }

        public SpriteEffects Effect
        {
            get => Flipbook.Effect;
            set => Flipbook.Effect = value;
        }

        public float LayerDepth
        {
            get => Flipbook.LayerDepth;
            set => Flipbook.LayerDepth = value;
        }

        public int SpriteHeight => Flipbook.SpriteHeight;

        public static MobileFlipbook CreateMobileFlipbook(MobileType MobileType, Vector2 Position)
        {
            MobileFlipbook mb = new MobileFlipbook();

            string spritePath = $"Graphics/Tank/{MobileType}/CharacterSpritesheet";

            switch (MobileType)
            {
                case MobileType.Random:
                    mb.Flipbook = Flipbook.CreateFlipbook(
                        Position, new Vector2(14, 23.5f), 28, 47, spritePath,
                        new AnimationInstance(), true, DepthParameter.Mobile);
                    break;
                case MobileType.Armor:
                    mb.Flipbook = Flipbook.CreateFlipbook(
                        Position, new Vector2(79, 88), 2900 / 20, 2990 / 23, spritePath,
                        new AnimationInstance(), true, DepthParameter.Mobile);
                    break;
                case MobileType.Bigfoot:
                    mb.Flipbook = Flipbook.CreateFlipbook(
                        Position, new Vector2(75, 88), 2580 / 20, 2470 / 19, spritePath,
                        new AnimationInstance(), true, DepthParameter.Mobile);
                    break;
                case MobileType.Dragon:
                    mb.Flipbook = Flipbook.CreateFlipbook(
                        Position, new Vector2(72.5f, 85f), 2500 / 20, 3240 / 27, spritePath,
                        new AnimationInstance(), true, DepthParameter.Mobile);
                    break;
                case MobileType.Mage:
                    mb.Flipbook = Flipbook.CreateFlipbook(
                        Position, new Vector2(52f, 85f), 2180 / 20, 3150 / 21, spritePath,
                        new AnimationInstance(), true, DepthParameter.Mobile);
                    break;
                case MobileType.Ice:
                    mb.Flipbook = Flipbook.CreateFlipbook(
                        Position, new Vector2(78f, 75f), 2960 / 20, 3150 / 21, spritePath,
                        new AnimationInstance(), true, DepthParameter.Mobile);
                    break;
                case MobileType.Knight:
                    mb.Flipbook = Flipbook.CreateFlipbook(
                        Position, new Vector2(59, 88), 2160 / 20, 2413 / 19, spritePath,
                        new AnimationInstance(), true, DepthParameter.Mobile);
                    break;
                case MobileType.Turtle:
                    mb.Flipbook = Flipbook.CreateFlipbook(
                        Position, new Vector2(59, 88), 2300 / 20, 3000 / 24, spritePath,
                        new AnimationInstance(), true, DepthParameter.Mobile);
                    break;
            }

            mb.StatePresets = MobileStatePresets[MobileType];
            mb.State = MobileFlipbookState.Moving;
            mb.ChangeState(MobileFlipbookState.Stand);

            //            if (mb.FlipbookSFX != null)
            //              mb.FlipbookSFX.Color = Color.;

            return mb;
        }

        private MobileFlipbook() { }

        public void Flip()
        {
            Flipbook.Flip();
        }

        public void SetAnimationFrame(int param)
        {
            Flipbook.SetCurrentFrame(param);
        }

        public void EnqueueAnimation(MobileFlipbookState NewState)
        {
            if (State == MobileFlipbookState.Dead) return;
            Flipbook.AppendAnimationIntoCycle(StatePresets[NewState]);
        }

        public void ChangeState(MobileFlipbookState NewState, bool Force = false)
        {
            AnimationInstance selectedPreset;

            if (StatePresets.ContainsKey(NewState))
                selectedPreset = StatePresets[NewState];
            else
                selectedPreset = StatePresets.First().Value;

            State = NewState;

            if (!selectedPreset.Equals(default(AnimationInstance)))
                Flipbook.AppendAnimationIntoCycle(selectedPreset, Force);
        }

        public void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            Flipbook.Draw(gameTime, spriteBatch);
        }
    }
}