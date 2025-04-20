    using UnityEngine;

    public interface IScorable
    {
        public int score { get; set; }
        public string name { get; set; }
        public Sprite weapon { get; set; }
        public string skin  { get; set; }
        
    }