﻿using Leopotam.EcsLite;
using SFML.System;

namespace Engine
{
	public struct CircularCollisionComponent
	{
		public Vector2f CenterOffset;
		public float Radius;
		public bool IsColliding;
	}
}
