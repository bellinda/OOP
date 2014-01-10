using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PopcornGame
{
    class AcademyPopcornMain
    {
        const int WorldRows = 23;
        const int WorldCols = 40;
        const int RacketLength = 6;

        static void Initialize(Engine engine)
        {
            int startRow = 3;
            int startCol = 2;
            int endCol = WorldCols - 2;

            for (int i = startCol; i < endCol; i++)
            {
                if (i % 3 == 0)
                {
                    ExplodingBlock currBlock = new ExplodingBlock(new MatrixCoords(startRow, i));
                    engine.AddObject(currBlock);
                    ExplodingBlock currBlock1 = new ExplodingBlock(new MatrixCoords(startRow + 1, i));
                    engine.AddObject(currBlock1);
                }
                else
                {
                    Block currBlock = new Block(new MatrixCoords(startRow, i));
                    engine.AddObject(currBlock);
                    Block currBlock1 = new Block(new MatrixCoords(startRow + 1, i));
                    engine.AddObject(currBlock1);
                }
            }

            for (int i = 0; i < 3; i++)
            {
                for (int k = 0; k < 3; k++)
                {
                    UnpassableBlock unBlock = new UnpassableBlock(new MatrixCoords(startRow + 7 + i, startCol + 11 + k));
                    engine.AddObject(unBlock);
                }
            }

            for (int i = 0; i < endCol + 1; i++)
            {
                IndestructibleBlock staticBlock = new IndestructibleBlock(new MatrixCoords(1, i));
                engine.AddObject(staticBlock);
            }

            for (int i = 1; i < WorldRows; i++)
            {
                IndestructibleBlock sideWallLeft = new IndestructibleBlock(new MatrixCoords(i, 0));
                engine.AddObject(sideWallLeft);
                IndestructibleBlock sideWallRight = new IndestructibleBlock(new MatrixCoords(i, WorldCols - 1));
                engine.AddObject(sideWallRight);
            }

            Gift gift = new Gift(new MatrixCoords(WorldRows / 2 - 7, WorldCols / 2));
            engine.AddObject(gift);
            //gift = new Gift(new MatrixCoords(WorldRows / 2 - 7, WorldCols / 2 - 2));
            //engine.AddObject(gift);
            gift = new Gift(new MatrixCoords(WorldRows / 2 - 7, WorldCols / 2 - 8));
            engine.AddObject(gift);

            GiftBlock giftBlock = new GiftBlock(new MatrixCoords(WorldRows / 2 - 4, 3));
            engine.AddObject(giftBlock);

            //MeteoriteBall theBall = new MeteoriteBall(new MatrixCoords(WorldRows / 2, 0),
            //    new MatrixCoords(-1, 1));
            //UnstoppableBall theBall = new UnstoppableBall(new MatrixCoords(WorldRows / 2, 0),
            //    new MatrixCoords(-1, 1));

            Ball theBall = new Ball(new MatrixCoords(WorldRows / 2, 0),
                new MatrixCoords(-1, 1));

            engine.AddObject(theBall);

            //TrailObject trail = new TrailObject(new MatrixCoords(WorldRows / 2 + 3, WorldCols / 2), 10);
            //engine.AddObject(trail);

            ShootingRacket theRacket = new ShootingRacket(new MatrixCoords(WorldRows - 1, WorldCols / 2), RacketLength);

            engine.AddObject(theRacket);
        }

        static void Main(string[] args)
        {
            IRenderer renderer = new ConsoleRenderer(WorldRows, WorldCols);
            IUserInterface keyboard = new KeyboardInterface();

            Engine gameEngine = new Engine(renderer, keyboard, 200);

            keyboard.OnLeftPressed += (sender, eventInfo) =>
            {
                gameEngine.MovePlayerRacketLeft();
            };

            keyboard.OnRightPressed += (sender, eventInfo) =>
            {
                gameEngine.MovePlayerRacketRight();
            };

            keyboard.OnActionPressed += (sender, eventInfo) =>
            {
                (new ShootingEngine(renderer, keyboard)).ShootPlayerRacket();
            };

            Initialize(gameEngine);

            //

            gameEngine.Run();
        }
    }
}
