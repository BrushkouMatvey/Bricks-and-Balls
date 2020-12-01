using System.Collections.Generic;
using Entitas;
using UnityEditor;
using UnityEngine;

public class LevelInirializeSystem : IInitializeSystem  {
	private Contexts _contexts;

    public LevelInirializeSystem(Contexts contexts) {
    	_contexts = contexts;
    }

	public void Initialize() {
		// Initialization code here
		var levelEntity = _contexts.game.CreateEntity();
		LevelLoader loader = new LevelLoader();
		loader.LoadLevel("D:/Docs/Learning/Programming/Unity/Bricks-and-Balls/Bricks-and-Balls/Assets/Scripts/Game/LevelsData/levels/Level_1.json");
		levelEntity.AddLevel(loader.Level);
		createBalls(levelEntity.level.value.NumOfBalls);
		createBlocks(levelEntity.level.value.Blocks);
	}
	private void createBalls(int numOfBalls)
	{
		for (int i = 0; i < numOfBalls; i++)
		{
			var ballEntity = _contexts.game.CreateEntity();
			ballEntity.isBall = true;
			ballEntity.AddPosition(new Vector2(0, 0));
			ballEntity.AddResource(_contexts.game.globals.value.ball);
		}
	}
	private void createBlocks(List<BlockStruct> blocksData)
	{
		foreach (var blockData in blocksData)
		{
			var blockEntity = _contexts.game.CreateEntity();
			blockEntity.isBlock = true;
			blockEntity.AddPosition(new Vector2(blockData.X, blockData.Y));
			switch (blockData.Type)
			{
				case BlockType.SimpleBlock:
					switch (blockData.SimpleBlockType)
					{	
						case SimpleBlockType.Circle:
							blockEntity.AddResource(_contexts.game.globals.value.rectangleSimpleBlock);
							break;
						case SimpleBlockType.Rectangle:
							Debug.Log("Rect");
							blockEntity.AddResource(_contexts.game.globals.value.rectangleSimpleBlock);
							break;
						case SimpleBlockType.Rhombus:
							blockEntity.AddResource(_contexts.game.globals.value.rectangleSimpleBlock);
							break;
						case SimpleBlockType.Triangle:
							blockEntity.AddResource(_contexts.game.globals.value.triangleSimpleBlock);
							break;
					}
					break;
				case  BlockType.BombBlock: 
					blockEntity.AddResource(_contexts.game.globals.value.bombBlock);
					break;
				case  BlockType.LaserBlock: 
					blockEntity.AddResource(_contexts.game.globals.value.laserBlock);
					break;
			}
		}
	}
}