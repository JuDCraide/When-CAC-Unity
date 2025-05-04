using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EpResult {
    public int guess;
    public int res;
    public int diff;
    public int points;
}

public class DateResult {
    public string guess;
    public string res;
    public int diff;
    public int points;
}

public class RoundResult {
    public EpResult ep;
    public DateResult date;
    public int roundTotal;
    public string title;
    public string image;
    public string id;
}

public class Result {
    RoundResult[] rounds;
    int epTotal = 0;
    int dateTotal = 0;
    int totalPoints = 0;
}

public class GuessVideo {
    public string formattedTitle;
    public string imageUrl;
    public string videoI;

    public GuessVideo(GuessVideoRes v) {
        this.formattedTitle = v.formatted_title;
        this.imageUrl = v.image_url;
        this.videoI = v.video_i;
    }
}

public class GuessVideoRes {
    public string formatted_title;
    public string image_url;
    public string video_i;
}

//public class ResultResponse {
//    responseVideo: VideoResponse
//    points: {
//        ep: number,
//        date: number,
//    }
//}


public class Game {
    public string uuid;
    public int latestEp;
    public string seed;
    public int round = 1;
    public GuessVideo currentGuessVideo = null;
    public Result result = new Result();

    public Game(string uuid, int latestEp, string seed) {
        this.uuid = uuid;
        this.latestEp = latestEp;
        this.seed = seed;
    }

    public Game(GameRes g) {
        this.uuid = g.uuid;
        this.latestEp = g.latestEp;
        this.seed = g.seed;
    }
}
