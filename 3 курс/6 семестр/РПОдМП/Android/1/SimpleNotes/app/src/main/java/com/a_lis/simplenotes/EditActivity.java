package com.a_lis.simplenotes;

import android.app.Activity;
import android.database.Cursor;
import android.os.Bundle;
import android.text.TextUtils;
import android.view.View;
import android.widget.Button;
import android.widget.EditText;
import java.text.SimpleDateFormat;
import java.util.Date;
import java.util.Locale;

public class EditActivity extends Activity {

    private EditText mTitleText;
    private EditText mBodyText;
    private Long mRowId;

    private DBTools mDbHelper;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_edit);

        mDbHelper = new DBTools(this);

        mTitleText = findViewById(R.id.note_edit_summary);
        mBodyText = findViewById(R.id.note_edit_description);

        Button confirmButton = findViewById(R.id.note_edit_button);
        mRowId = null;
        Bundle extras = getIntent().getExtras();

        mRowId = (savedInstanceState == null) ? null
                : (Long) savedInstanceState
                .getSerializable(DBTools.COLUMN_ID);
        if (extras != null) {
            mRowId = extras.getLong(DBTools.COLUMN_ID);
        }

        populateFields();

        confirmButton.setOnClickListener(new View.OnClickListener() {
            public void onClick(View view) {
                if (TextUtils.isEmpty(mTitleText.getText().toString())) {
                    SimpleDateFormat formatDate = new SimpleDateFormat("dd.MM.yyyy hh:mm:ss", Locale.getDefault());
                    mTitleText.setText(formatDate.format(new Date()));
//                    Toast.makeText(EditActivity.this, "Данные не введены",
//                            Toast.LENGTH_LONG).show();
                }
                saveState();
                setResult(RESULT_OK);
                finish();
            }
        });
    }

    private void populateFields() {
        if (mRowId != null) {
            Cursor todo = mDbHelper.getNote(mRowId);

            mTitleText.setText(todo.getString(todo
                    .getColumnIndexOrThrow(DBTools.COLUMN_TITLE)));
            mBodyText.setText(todo.getString(todo
                    .getColumnIndexOrThrow(DBTools.COLUMN_DESCRIPTION)));
            todo.close();
        }
    }

    @Override
    protected void onSaveInstanceState(Bundle outState) {
        super.onSaveInstanceState(outState);
    }

    @Override
    protected void onPause() {
        super.onPause();
        //saveState();
    }

    @Override
    protected void onResume() {
        super.onResume();
        populateFields();
    }

    private void saveState() {
        String summary = mTitleText.getText().toString();
        String description = mBodyText.getText().toString();

        if (description.length() == 0 && summary.length() == 0) {
            return;
        }

        if (mRowId == null) {
            long id = mDbHelper.createNewNote(summary, description);
            if (id > 0) {
                mRowId = id;
            }
        } else {
            mDbHelper.updateNote(mRowId, summary, description);
        }
    }
}