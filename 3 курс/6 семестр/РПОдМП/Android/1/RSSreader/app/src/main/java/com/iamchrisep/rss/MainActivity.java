package com.iamchrisep.rss;

import android.app.Activity;
import android.content.Intent;
import android.os.AsyncTask;
import android.os.Bundle;
import android.view.Gravity;
import android.view.View;
import android.widget.AdapterView;
import android.widget.ArrayAdapter;
import android.widget.Button;
import android.widget.ListView;
import android.widget.TextView;
import android.widget.Toast;

import org.w3c.dom.Document;
import org.w3c.dom.Element;
import org.w3c.dom.NodeList;

import java.io.InputStream;
import java.net.HttpURLConnection;
import java.net.URL;
import java.text.SimpleDateFormat;
import java.util.ArrayList;
import java.util.Date;
import java.util.Locale;

import javax.xml.parsers.DocumentBuilder;
import javax.xml.parsers.DocumentBuilderFactory;

public class MainActivity extends Activity {

    public static RssItem selectedRssItem = null;
//    String feedUrl = "";
    ListView rssListView = null;
    ArrayList<RssItem> rssItems = new ArrayList<RssItem>();
    ArrayAdapter<RssItem> aa = null;

    @Override
    public void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_main);

        final TextView rssURLTV = (TextView) findViewById(R.id.rssURL);
        Button btnFetchRss = (Button) findViewById(R.id.fetchRss);

        // define the action that will be executed when the button is clicked.
        btnFetchRss.setOnClickListener(new View.OnClickListener() {

            @Override
            public void onClick(View v) {
                String feedUrl = rssURLTV.getText().toString();

                RetrieveFeedTask retrieveFeedTask = new RetrieveFeedTask();
                retrieveFeedTask.execute(feedUrl);
//                aa.notifyDataSetChanged();
            }
        });

        rssListView = (ListView) findViewById(R.id.rssListView);
        rssListView.setOnItemClickListener(new AdapterView.OnItemClickListener() {

            //@Override
            public void onItemClick(AdapterView<?> av, View view, int index,
                                    long arg3) {
                selectedRssItem = rssItems.get(index);

                Intent intent = new Intent(MainActivity.this, ViewActivity.class);
                intent.putExtra(RssItem.RSS_LINK, selectedRssItem.getLink());
                startActivityForResult(intent, 0);

//                Intent intent = new Intent(
//                        "rembo.network.urss.displayRssItem");
//                startActivity(intent);
            }
        });

        aa = new ArrayAdapter<>(this, R.layout.list_rssitem, rssItems);
        aa.setNotifyOnChange(true);
        rssListView.setAdapter(aa);

        int duration = Toast.LENGTH_LONG;
        Toast toast = Toast.makeText(getApplicationContext(),
                "Кристина Богданова, 2018",
                duration);
        toast.setGravity(Gravity.CENTER, 0, 0);
        toast.show();
    }

    private class RetrieveFeedTask extends AsyncTask<String, Void, ArrayList<RssItem>> {

        protected ArrayList<RssItem> doInBackground(String... urls) {
            ArrayList<RssItem> rssItems = new ArrayList<>();

            try {
                //open an URL connection make GET to the server and
                //take xml RSS data
                URL url = new URL(urls[0]);
                HttpURLConnection conn = (HttpURLConnection) url.openConnection();

                if (conn.getResponseCode() == HttpURLConnection.HTTP_OK) {
                    InputStream is = conn.getInputStream();

                    //DocumentBuilderFactory, DocumentBuilder are used for
                    //xml parsing
                    DocumentBuilderFactory dbf = DocumentBuilderFactory.newInstance();
                    DocumentBuilder db = dbf.newDocumentBuilder();

                    //using db (Document Builder) parse xml data and assign
                    //it to Element
                    Document document = db.parse(is);
                    Element element = document.getDocumentElement();

                    //take rss nodes to NodeList
                    NodeList nodeList = element.getElementsByTagName("item");
                    SimpleDateFormat simpleDateFormat = new SimpleDateFormat("EEE, dd MMM yyyy HH:mm:ss Z", Locale.US);

                    if (nodeList.getLength() > 0) {
                        for (int i = 0; i < nodeList.getLength(); i++) {

                            //take each entry (corresponds to <item></item> tags in
                            //xml data

                            Element entry = (Element) nodeList.item(i);

                            Element _titleE = (Element) entry.getElementsByTagName("title").item(0);
                            Element _descriptionE = (Element) entry.getElementsByTagName("description").item(0);
                            Element _pubDateE = (Element) entry.getElementsByTagName("pubDate").item(0);
                            Element _linkE = (Element) entry.getElementsByTagName("link").item(0);

                            String _title = _titleE.getFirstChild().getNodeValue();
                            String _description = _descriptionE.getFirstChild().getNodeValue();
                            Date _pubDate = simpleDateFormat.parse(_pubDateE.getFirstChild().getNodeValue());
                            String _link = _linkE.getFirstChild().getNodeValue();

                            //create RssItemObject and add it to the ArrayList
                            RssItem rssItem = new RssItem(_title, _description, _pubDate, _link);

                            rssItems.add(rssItem);
                        }
                    }

                }
            } catch (Exception e) {
                e.printStackTrace();
            }

            return rssItems;
        }

        protected void onPostExecute(ArrayList<RssItem> feed) {
            rssItems.clear();
            rssItems.addAll(feed);
            aa.notifyDataSetChanged();

            //TextView TVtitle=(TextView)findViewById(R.id.label);
            //CharSequence cs="0";
            //if(newItems.size()>0) cs="is 1";
            //if(newItems.size()>5) cs="is 5";
            ///TVtitle.setText(cs);
        }
    }
}
