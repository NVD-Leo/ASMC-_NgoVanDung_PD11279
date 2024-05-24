using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System.IO;
using System.Threading;
using JetBrains.Annotations;
using System.Runtime.CompilerServices;
using UnityEditor.Experimental.GraphView;
using System;

public class ASM_MN : Singleton<ASM_MN>
{
    public List<Region> listRegion = new List<Region>();
    public List<Players> listPlayer = new List<Players>();

    private void Start()
    {
        createRegion();
    }

    public void createRegion()
    {
        listRegion.Add(new Region(0, "VN"));
        listRegion.Add(new Region(1, "VN1"));
        listRegion.Add(new Region(2, "VN2"));
        listRegion.Add(new Region(3, "JS"));
        listRegion.Add(new Region(4, "VS"));
        listPlayer.Add(new Players(1234, "Dat", 150, listRegion[0]));
        listPlayer.Add(new Players(2345, "Khanh", 500, listRegion[1]));
        listPlayer.Add(new Players(3456, "Dung", 1000, listRegion[2]));
    }

    public string calculate_rank(int score)
    {
        if (score < 100) { return "Dong"; }
        else if (score < 500) { return "Bac"; }
        else if (score < 1000) { return "Vang"; }
        else if(score >= 1000) { return "Kim cuong"; }
        else
        return null;
    }

    public void YC1(int id, string name, int score, Region IDregion)
    {
        Players player = new Players(ScoreKeeper.Instance.ID, ScoreKeeper.Instance.userName, ScoreKeeper.Instance.score, listRegion[ScoreKeeper.Instance.IDregion]);
        listPlayer.Add(player);
    }
public void YC2()
    {
        foreach ( Players player in listPlayer )
        {
            string rank = calculate_rank(player.Score);
            Debug.Log($"ID: {player.Id}, Name: {player.Name}, Score:{player.Score}, Region: {player.region.Name}, Rank: {rank}");
        }
    }
    public void YC3()
    {
        foreach (var player in listPlayer.Where(p => p.Score < ScoreKeeper.Instance.score ))
        {
            string rank = calculate_rank(player.Score);
            Debug.Log($"Id: {player.Id}, Name: {player.Name}, Score: {player.Score}, Region: {player.region.Name}, Rank: {rank}");
        }
    }
    public void YC4()
    {
        
        var player = listPlayer.FirstOrDefault(p => p.Id == ScoreKeeper.Instance.ID);
        if (player != null)
        {
            string rank = calculate_rank(player.Score);
            Debug.Log($"Id: {player.Id}, Name: {player.Name}, Score: {player.Score}, Region: {player.region.Name}, Rank: {rank}");
        }
        else
        {
            Debug.Log("Player not found");
        }
    }
    public void YC5()
    {
        foreach (var player in listPlayer.OrderByDescending(p => p.Score))
        {
            string rank = calculate_rank(player.Score) ;
            Debug.Log($"Id: {player.Id}, Name: {player.Name}, Score: {player.Score}, Region: {player.region.Name},Rank: {rank}");
        }
    }
    public void YC6()
    {
        foreach (var player in listPlayer.OrderBy(p => p.Score).Take(5))
        {
            string rank = calculate_rank(player.Score);
            Debug.Log($"Id: {player.Id}, Name: {player.Name}, Score: {player.Score}, Region: {player.region.Name},Rank: {rank}");
        }
    }
    public void YC7()
    {
        Thread thread = new Thread(CalculateAndSaveAverageScoreByRegion);
        thread.Name = "BXH";
        thread.Start();
    }
    void CalculateAndSaveAverageScoreByRegion()
    {
        var regionGroups = listPlayer.GroupBy(p => p.region)
                                    .Select(g => new
                                    {
                                        Region = g.Key,
                                        AverageScore = g.Average(p => p.Score)
                                    });

        using (System.IO.StreamWriter file = new System.IO.StreamWriter("bxhRegion.txt"))
        {
            foreach (var region in regionGroups)
            {
                file.WriteLine($"Region: {region.Region.Name}, Average Score: {region.AverageScore}");
            }
        }
    }
}

[SerializeField]
public class Region
{
    public int ID;
    public string Name;
    public Region(int ID, string Name)
    {
        this.ID = ID;
        this.Name = Name;
    }
}

[SerializeField]
public class Players
{
    public int Id;
    public string Name;
    public int Score;
    public Region region;
    public Players( int Id, string Name, int Score, Region region)
    {
        this.Id = Id;
        this.Name = Name;
        this.Score = Score;
        this.region = region;

    }
}