package com.iamchrisep.qrcodetool;

import android.content.Intent;
import android.graphics.Bitmap;
import android.support.v7.app.AppCompatActivity;
import android.os.Bundle;
import android.view.Gravity;
import android.view.View;
import android.widget.Button;
import android.widget.EditText;
import android.widget.ImageView;
import android.widget.Toast;

import com.google.zxing.BarcodeFormat;
import com.google.zxing.WriterException;

import static java.lang.Math.min;

public class MainActivity extends AppCompatActivity {

    EditText edtText;
    Button btnEncode;
    ImageView imgQR;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_main);

        edtText = findViewById(R.id.edtText);
        btnEncode = findViewById(R.id.btn_QREncode);
        imgQR = findViewById(R.id.imgQR);


        btnEncode.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                String text = edtText.getText().toString();
                Bitmap bitmap = null;
                try {
                    int imgSize = min(imgQR.getWidth(), imgQR.getHeight());
                    bitmap = QREncoder.encodeAsBitmap(text, BarcodeFormat.QR_CODE, imgSize, imgSize);
                } catch (WriterException e) {
                    e.printStackTrace();
                }
                imgQR.setImageBitmap(bitmap);
            }
        });

        findViewById(R.id.btn_QRDecode).setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                startActivity(new Intent(MainActivity.this, DecodeActivity.class));
            }
        });

        findViewById(R.id.button).setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                int duration = Toast.LENGTH_LONG;
                Toast toast = Toast.makeText(getApplicationContext(),
                        "Кристина Богданова, 2018",
                        duration);
                toast.setGravity(Gravity.CENTER, 0, 0);
                toast.show();
            }
        });
    }
}
