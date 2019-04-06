package com.iamchrisep.rss;

import java.util.Date;

public class RssItem {
    private String link;
    private String title;
    private String description;
    private Date pubDate;

    static final String RSS_LINK = "rss_link";

    public String getLink(){
        return link;
    };
    public String getTitle(){
        return title;
    };
    private String getDescription(){
        return description;
    };
    private Date getPubDate(){
        return pubDate;
    };

    RssItem(String title, String description, Date pubDate, String link){
        this.pubDate = pubDate;
        this.description = description;
        this.link = link;
        this.title = title;
    }

    @Override
    public String toString(){
        return this.title;
    }
}
