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
    public Dictionary<int, RoundResult> rounds = new Dictionary<int, RoundResult>();
    public int epTotal = 0;
    public int dateTotal = 0;
    public int totalPoints = 0;
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

[Serializable]
public class GuessVideoRes {
    public string formatted_title;
    public string image_url;
    public string video_i;
}

[Serializable]
public class PointsRes {
    public int ep;
    public int date;
}

[Serializable]
public class VideoResponse {
    public string title;
    public int ep;
    public string video_id;
    public string date;
}

[Serializable]
public class ResultResponse {
    public VideoResponse responseVideo;
    public PointsRes points;
}

public class VideoResponseReq {
    public string uuid;
    public int round;
    public int ep;
    public string date;

    public VideoResponseReq(string uuid, int round, int ep, string date) {
        this.uuid = uuid;
        this.round = round;
        this.ep = ep;
        this.date = date;
    }
}


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

    public void saveResult(ResultResponse r) {
        result.totalPoints += r.points.ep + r.points.date;
        result.epTotal += r.points.ep;
        result.dateTotal += r.points.date;

        result.rounds.Add(this.round,
            new RoundResult {
                date = new DateResult {
                    guess = DateInput.value,
                    res = r.responseVideo.date,
                    diff = Math.Abs((DateTime.Parse(r.responseVideo.date) - DateTime.Parse(DateInput.value)).Days),
                    points = r.points.date
                },
                ep = new EpResult {
                    guess = EpInput.currentValue,
                    res = r.responseVideo.ep,
                    diff = Math.Abs(r.responseVideo.ep - EpInput.currentValue),
                    points = r.points.ep
                },
                roundTotal = r.points.ep + r.points.date,
                title = r.responseVideo.title,
                image = currentGuessVideo.imageUrl,
                id = r.responseVideo.video_id,
            }
        );
    }
}
