using System.Collections.Generic;
using Entitas;
using UnityEditor;
using UnityEngine;

public class LevelInirializeSystem : IInitializeSystem  {
	private Contexts _contexts;
	
	private Vector3 bottomLeftScreenPoint; 
	private Vector3 topRightScreenPoint; 
	private List<int> visableArea;
	public LevelInirializeSystem(Contexts contexts) {
    	_contexts = contexts;
        bottomLeftScreenPoint = Camera.main.ScreenToWorldPoint(new Vector3(0f, 0f, 0f));
        topRightScreenPoint = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 0f));
    }

	public void Initialize() {
		// Initialization code here
		var levelEntity = _contexts.game.CreateEntity();
		LevelController loader = new LevelController();
		loader.LoadLevel(_contexts.game.globals.value.level);
		levelEntity.AddLevel(loader.Level);
		visableArea = levelEntity.level.value.VisibleAreaSize;
		createBalls(levelEntity.level.value.NumOfBalls);
		createBlocks(levelEntity.level.value.Blocks);
	}
	private void createBalls(int numOfBalls)
	{
		for (int i = 0; i < numOfBalls; i++)
		{
			var ballEntity = _contexts.game.CreateEntity();
			ballEntity.isBall = true;

			ballEntity.AddResource(_contexts.game.globals.value.ball);
			ballEntity.ReplacePosition(new Vector2(0, -topRightScreenPoint.y + 0.18f));
		}
	}
	private void createBlocks(List<BlockStruct> blocksData)
	{
		foreach (var blockData in blocksData)
		{
			var blockEntity = _contexts.game.CreateEntity();
			blockEntity.AddHealth(blockData.Health);

			switch (blockData.Type)
			{
				case BlockType.SimpleBlock:
					blockEntity.isBlock = true;
					switch (blockData.SimpleBlockType)
					{	
						case SimpleBlockType.Circle:
							blockEntity.AddResource(_contexts.game.globals.value.circleSimpleBlock);
							break;
						case SimpleBlockType.Rectangle:
							blockEntity.AddResource(_contexts.game.globals.value.rectangleSimpleBlock);
							break;
						case SimpleBlockType.Rhombus:
							blockEntity.AddResource(_contexts.game.globals.value.rhombusSimpleBlock);
							break;
						case SimpleBlockType.Triangle:
							blockEntity.AddResource(_contexts.game.globals.value.triangleSimpleBlock);
							break;
					}
					break;
				case  BlockType.BombBlock: 
					blockEntity.AddResource(_contexts.game.globals.value.bombBlock);
					blockEntity.AddBombBlock(blockData.Damage, blockData.DamageAreaSize);
					break;
				case  BlockType.LaserBlock: 
					blockEntity.AddResource(_contexts.game.globals.value.laserBlock);
					break;
			}
			blockEntity.ReplacePosition(new Vector2(blockData.X, blockData.Y));
		}
	}
}