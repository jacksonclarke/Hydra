namespace Unit05.Game.Casting{
    public class Enemies : Actor{
        private int pointVal;
        public Enemies(int points){
            pointVal = points;
        }
        public int getPoints(){
            return pointVal;
        }
    }
}