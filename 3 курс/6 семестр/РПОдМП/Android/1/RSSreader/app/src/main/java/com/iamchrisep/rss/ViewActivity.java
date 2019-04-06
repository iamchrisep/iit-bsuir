package com.iamchrisep.rss;

import android.app.Activity;
import android.os.Bundle;
import android.webkit.WebView;

public class ViewActivity extends Activity {

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_view);
        WebView webView = findViewById(R.id.rss_view);
        Bundle extras = getIntent().getExtras();
        String link = extras.getString(RssItem.RSS_LINK);
        webView.loadUrl(link);
    }
}
