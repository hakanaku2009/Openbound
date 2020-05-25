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
using OpenBound.GameComponents.Animation;
using OpenBound.GameComponents.Level.Scene;
using OpenBound.GameComponents.Pawn.Unit;
using OpenBound.GameComponents.PawnAction;
using Openbound_Network_Object_Library.Entity;
using System;
using System.Collections.Generic;
using System.Linq;

namespace OpenBound.GameComponents.Pawn.UnitProjectiles
{
    public class TurtleProjectileEmitter
    {
        //This method was created to prevent hurricane positions
        public static void Shot2(Turtle mobile)
        {
            mobile.LastCreatedProjectileList.Add(new TurtleProjectile2(mobile, 0));
            mobile.LastCreatedProjectileList.Add(new TurtleProjectile2(mobile, MathHelper.Pi));
        }

        public static void Shot3(Turtle mobile, float force, Vector2 position, float rotation, Action onFinalizeExecution)
        {
            //6 projectiles
            float angleOffset = MathHelper.ToRadians(Parameter.ProjectileTurtleSSAngleOffsetDegrees);

            for (int i = (int)-Parameter.ProjectileTurtleSSBubbleNumber / 2; i < Parameter.ProjectileTurtleSSBubbleNumber / 2; i++)
            {
                TurtleProjectile3SS newProj = new TurtleProjectile3SS(mobile, position, force / Parameter.ProjectileTurtleSSDampeningFactor, rotation + angleOffset * i + angleOffset / 2);
                newProj.OnFinalizeExecution = onFinalizeExecution;
                mobile.LastCreatedProjectileList.Add(newProj);
            }
        }
    }

    public class TurtleProjectile1 : DummyProjectile
    {
        HelicoidalTrace trace;

        public TurtleProjectile1(Turtle mobile)
            : base(mobile, ShotType.S1, Parameter.ProjectileTurtleS1ExplosionRadius, Parameter.ProjectileTurtleS1BaseDamage)
        {
            trace = new HelicoidalTrace(MobileType.Turtle, ShotType.S1, Color.White);

            mass = Parameter.ProjectileTurtleS1Mass;
            windInfluence = Parameter.ProjectileTurtleS1WindInfluence;
        }

        public override void Update()
        {
            base.Update();
            trace.Update(FlipbookList[0].Position, Vector2.Zero, FlipbookList[0].Rotation, 0, 0);
        }

        protected override void Explode()
        {
            base.Explode();
            SpecialEffectBuilder.TurtleProjectile1Explosion(FlipbookList[0].Position, FlipbookList[0].Rotation);
        }

        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            if (SpawnTimeCounter < SpawnTime) return;
            base.Draw(gameTime, spriteBatch);
            trace.Draw(gameTime, spriteBatch);
        }
    }

    public class TurtleProjectile2 : DummyProjectile
    {
        HelicoidalTrace trace;
        float angleDecreasingOffsetTimer;
        float angleFactor;
        float angleOffset;

        DummyProjectile dProj;

        public TurtleProjectile2(Turtle mobile, float angleOffset)
            : base(mobile, ShotType.S2, 0, 0, canCollide: false)
        {
            trace = new HelicoidalTrace(MobileType.Turtle, ShotType.S2, Color.White);

            this.angleOffset = angleOffset;
            angleDecreasingOffsetTimer = Parameter.ProjectileTurtleS2AngleOffsetTimer;
            angleFactor = 1f;

            dProj = new DummyProjectile(mobile, ShotType.S2, Parameter.ProjectileTurtleS2ExplosionRadius, Parameter.ProjectileTurtleS2BaseDamage);

            mass = Parameter.ProjectileTurtleS2Mass;
            windInfluence = Parameter.ProjectileTurtleS2WindInfluence;
        }

        protected override void Explode()
        {
            base.Explode();
            SpecialEffectBuilder.TurtleProjectile2Explosion(trace.Position, FlipbookList[0].Rotation);
        }

        public override void Update()
        {
            base.Update();

            for (float i = 0; i < Parameter.ProjectileMovementTotalTimeElapsed; i += Parameter.ProjectileMovementTimeElapsedPerInteraction)
            {
                angleDecreasingOffsetTimer -= Parameter.ProjectileMovementTimeElapsedPerInteraction;
                if (angleDecreasingOffsetTimer < 0)
                    angleFactor = Math.Max(0, angleFactor - Parameter.ProjectileTurtleS2AngleOffsetFactor * Parameter.ProjectileMovementTimeElapsedPerInteraction);

                trace.Update(FlipbookList[0].Position, new Vector2(0, 20), FlipbookList[0].Rotation, Parameter.ProjectileMovementTimeElapsedPerInteraction, angleOffset, Parameter.ProjectileTurtleS2RotationFactor, angleFactor);

                dProj.FlipbookList[0].Position = trace.Position;

                if (dProj.CheckOutOfBounds(trace.Position))
                    return;

                if (dProj.UpdateCollider(trace.Position))
                {
                    Explode();
                    return;
                }
            }
        }

        public override bool CheckOutOfBounds(Vector2 position)
        {
            return base.CheckOutOfBounds(trace.Position);
        }

        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            if (SpawnTimeCounter < SpawnTime) return;
            base.Draw(gameTime, spriteBatch);
            trace.Draw(gameTime, spriteBatch);
        }
    }

    public class TurtleProjectile3 : Projectile
    {
        ProjectileAnimation bubbleAnimation;
        float totalTravelledTime;

        public TurtleProjectile3(Turtle mobile)
            : base(mobile, ShotType.SS, Parameter.ProjectileTurtleSSExplosionRadius, Parameter.ProjectileTurtleSSBaseDamage)
        {
            //Initializing Flipbook
            FlipbookList.Add(Flipbook.CreateFlipbook(
                mobile.Crosshair.CannonPosition, new Vector2(26, 22.5f),
                52, 45, "Graphics/Tank/Turtle/Bullet3",
                new AnimationInstance() { StartingFrame = 0, EndingFrame = 14, TimePerFrame = 1 / 20f },
                true, DepthParameter.Projectile));

            //Physics/Trajectory setups
            mass = Parameter.ProjectileTurtleSSMass;
            windInfluence = Parameter.ProjectileTurtleSSWindInfluence;
        }

        protected override void UpdatePosition()
        {
            switch (bubbleAnimation)
            {
                case ProjectileAnimation.Closed:
                    if (totalTravelledTime < Parameter.ProjectileTurtleSSTransformTime)
                    {
                        totalTravelledTime += Parameter.ProjectileMovementTotalTimeElapsed;
                        base.UpdatePosition();
                    }
                    else
                    {
                        bubbleAnimation = ProjectileAnimation.Opening;
                    }
                    break;
                case ProjectileAnimation.Opening:
                    bubbleAnimation = ProjectileAnimation.Opened;
                    SpecialEffectBuilder.TurtleProjectile3Division(FlipbookList[0].Position, FlipbookList[0].Rotation);
                    TurtleProjectileEmitter.Shot3((Turtle)mobile, force, FlipbookList[0].Position, FlipbookList[0].Rotation, OnFinalizeExecution);
                    PlayExplosionSFX();
                    GameScene.Camera.TrackObject(mobile.LastCreatedProjectileList.First());
                    break;
                case ProjectileAnimation.Opened:
                    base.Destroy();
                    break;
            }
        }

        protected override void Explode()
        {
            base.Explode();
            SpecialEffectBuilder.TurtleProjectile3Explosion(FlipbookList[0].Position, FlipbookList[0].Rotation);
        }

        protected override void Destroy()
        {
            base.Destroy();

            List<Projectile> pjList = mobile.ProjectileList.Except(mobile.UnusedProjectile).ToList();

            if (pjList.Count() == 0)
                OnFinalizeExecution?.Invoke();
        }
    }

    public class TurtleProjectile3SS : Projectile
    {
        public TurtleProjectile3SS(Turtle mobile, Vector2 positionModifier, float force, float angle)
            : base(mobile, ShotType.SS, Parameter.ProjectileTurtleSSEExplosionRadius, Parameter.ProjectileTurtleSSEBaseDamage, positionModifier)
        {
            //Initializing Flipbook
            FlipbookList.Add(Flipbook.CreateFlipbook(
                positionModifier, new Vector2(15, 13.5f),
                30, 27, "Graphics/Tank/Turtle/Shot3",
                new AnimationInstance() { StartingFrame = 0, EndingFrame = 14, TimePerFrame = 1 / 20f },
                true, DepthParameter.Projectile));

            FlipbookList[0].JumpToRandomAnimationFrame();

            //Physics/Trajectory setups
            mass = Parameter.ProjectileTurtleSSMass;
            windInfluence = Parameter.ProjectileTurtleSSWindInfluence;

            xSpeedComponent = (float)Math.Round(Math.Cos(angle), 3);
            ySpeedComponent = (float)Math.Round(Math.Sin(angle), 3);

            yMovement.Preset(ySpeedComponent * force * Parameter.ProjectileMovementForceFactor / mass, Parameter.ProjectileMovementGravity + ywSpeedComponent * wForce * windInfluence);
            xMovement.Preset(xSpeedComponent * force * Parameter.ProjectileMovementForceFactor / mass, xwSpeedComponent * wForce * windInfluence);
        }

        //Prevents any sound from being played when the projectile is spawned
        public override void OnSpawn() { }

        protected override void Destroy()
        {
            base.Destroy();

            List<Projectile> pjList = mobile.ProjectileList.Except(mobile.UnusedProjectile).ToList();

            if (pjList.Count() == 0)
                OnFinalizeExecution?.Invoke();
            else if (GameScene.Camera.TrackedObject == this)
                GameScene.Camera.TrackObject(mobile.ProjectileList.Union(mobile.LastCreatedProjectileList).First());
        }

        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            base.Draw(gameTime, spriteBatch);
            mobile.LastCreatedProjectileList.ForEach((x) => x.Draw(gameTime, spriteBatch));
        }
    }
}