using Leopotam.EcsLite;
using Leopotam.EcsLite.Di;

namespace Engine
{
	public class AnimationSystem : IEcsRunSystem
	{
		public void Run(IEcsSystems systems)
		{
			foreach (int entity in m_animationFilter.Value)
			{
				ref RendererComponent rendererComp = ref m_rendererPool.Value.Get(entity);
				ref AnimationComponent animationComp = ref m_animationPool.Value.Get(entity);
				animationComp.AnimationCurrentTime += EngineData.DeltaTime;
				animationComp.AnimationCurrentTime = animationComp.AnimationCurrentTime > animationComp.AnimationTime ? 0 : animationComp.AnimationCurrentTime;
				rendererComp.Sprite = SpriteUtility.GetSprite(animationComp.SpritesNames[(int)(animationComp.AnimationCurrentTime * animationComp.SpritesNumber / animationComp.AnimationTime)]);
			}
		}

		private EcsFilterInject<Inc<TransformComponent, RendererComponent, AnimationComponent>> m_animationFilter;
		private EcsPoolInject<RendererComponent> m_rendererPool;
		private EcsPoolInject<AnimationComponent> m_animationPool;
	}
}
