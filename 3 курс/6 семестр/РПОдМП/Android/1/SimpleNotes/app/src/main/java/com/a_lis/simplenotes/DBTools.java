package com.a_lis.simplenotes;

import android.content.ContentValues;
import android.content.Context;
import android.database.Cursor;
import android.database.SQLException;
import android.database.sqlite.SQLiteDatabase;
import android.database.sqlite.SQLiteOpenHelper;
import android.util.Log;

public class DBTools extends SQLiteOpenHelper {

    private static final String DATABASE_NAME = "notes_app.db";
    private static final int DATABASE_VERSION = 3;
    private static final String DATABASE_TABLE = "notes";

    // поля таблицы
    static final String COLUMN_ID = "_id";
    static final String COLUMN_TITLE = "title";
    static final String COLUMN_DESCRIPTION = "description";

    // запрос на создание базы данных
    private static final String DATABASE_CREATE =
            "create table " + DATABASE_TABLE + "("
            + COLUMN_ID + " integer primary key autoincrement, "
            + COLUMN_TITLE + " text not null,"
            + COLUMN_DESCRIPTION + " text not null" + ");";

    DBTools(Context context) {
        super(context, DATABASE_NAME, null, DATABASE_VERSION);
    }

    @Override
    public void onCreate(SQLiteDatabase db) {
        db.execSQL(DATABASE_CREATE);
    }

    @Override
    public void onUpgrade(SQLiteDatabase db, int oldVersion, int newVersion) {
        Log.w(DBTools.class.getName(), "Upgrading database from version "
                + oldVersion + " to " + newVersion
                + ", which will destroy all old data");
        db.execSQL("DROP TABLE IF EXISTS todos");
        onCreate(db);
    }

    long createNewNote(String title,
                       String description) {
        SQLiteDatabase db = this.getWritableDatabase();
        ContentValues initialValues = createContentValues(title, description);

        long row = db.insert(DATABASE_TABLE, null, initialValues);
        db.close();

        return row;
    }

    void updateNote(long rowId, String title, String description) {
        SQLiteDatabase db = this.getWritableDatabase();
        ContentValues updateValues = createContentValues(title, description);

        db.update(DATABASE_TABLE, updateValues,COLUMN_ID + "=" + rowId,null);
    }

    void deleteNote(long rowId) {
        SQLiteDatabase db = this.getWritableDatabase();
        db.delete(DATABASE_TABLE, COLUMN_ID + "=" + rowId, null);
        db.close();
    }

    /*Cursor getAllData() {
        SQLiteDatabase db = this.getWritableDatabase();
        return db.query(DATABASE_TABLE, new String[] { COLUMN_ID,
                        COLUMN_TITLE, COLUMN_DESCRIPTION }, null,
                null, null, null, null);
    }*/

    Cursor getDataByQuery(String s) {
        SQLiteDatabase db = this.getWritableDatabase();
        return db.query(DATABASE_TABLE, new String[] { COLUMN_ID,
                        COLUMN_TITLE, COLUMN_DESCRIPTION },
                COLUMN_TITLE + " LIKE" + "'%" + s + "%' or "+
                        COLUMN_DESCRIPTION + " LIKE" + "'%" + s + "%'",
                null, null, null, null);
    }

    Cursor getNote(long rowId) throws SQLException {
        SQLiteDatabase db = this.getReadableDatabase();
        Cursor mCursor = db.query(true, DATABASE_TABLE,
                new String[] { COLUMN_ID, COLUMN_TITLE,
                        COLUMN_DESCRIPTION }, COLUMN_ID + "=" + rowId, null,
                null, null, null, null);
        if (mCursor != null) {
            mCursor.moveToFirst();
        }
        return mCursor;
    }

    private ContentValues createContentValues(String title, String description) {
        ContentValues values = new ContentValues();
        values.put(COLUMN_TITLE, title);
        values.put(COLUMN_DESCRIPTION, description);
        return values;
    }
}