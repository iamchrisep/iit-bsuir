package com.iamchrisep.qrcodetool;

import android.content.ClipData;
import android.content.ClipboardManager;
import android.content.Context;
import android.content.Intent;
import android.net.Uri;
import android.support.v7.app.AppCompatActivity;
import android.os.Bundle;
import android.view.View;
import android.widget.Button;
import android.widget.TextView;

import com.google.zxing.Result;

import java.net.URI;
import java.net.URL;

public class DecodingResultActivity extends AppCompatActivity {

    private static final int ACTION_COPY_TEXT = 1;
    private static final int ACTION_OPEN_URL = 2;

    TextView textViewResult;
    Button btnAction;
    String result = "";
    private int action;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_decodingresult);

        textViewResult = findViewById(R.id.textViewResult);
        btnAction = findViewById(R.id.btnAction);

//        Result decodeResult;

        Bundle extras = getIntent().getExtras();
        if (extras != null) {
            result = extras.getString("DecodeResult");
        }

        textViewResult.setText(result);
            if (isValidURL(result)) {
                action = ACTION_OPEN_URL;
                btnAction.setText(R.string.open_url);
            } else {
                action = ACTION_COPY_TEXT;
                btnAction.setText(R.string.copy_text);
            }

    }

    private boolean isValidURL(String urlString)
    {
        try
        {
            URL url = new URL(urlString);
            url.toURI();
            return true;
        } catch (Exception exception)
        {
            return false;
        }
    }

    public void onActionClick(View view) {
        switch (action) {
            case ACTION_COPY_TEXT:
                ClipboardManager clipboard = (ClipboardManager) getSystemService(Context.CLIPBOARD_SERVICE);
                ClipData clip = ClipData.newPlainText("", result);
                if (clipboard != null) {
                    clipboard.setPrimaryClip(clip);
                }
                break;
            case ACTION_OPEN_URL:
                Uri address = Uri.parse(result);
                Intent openlink = new Intent(Intent.ACTION_VIEW, address);
                startActivity(Intent.createChooser(openlink, "Browser"));
                break;
        }
    }
}
