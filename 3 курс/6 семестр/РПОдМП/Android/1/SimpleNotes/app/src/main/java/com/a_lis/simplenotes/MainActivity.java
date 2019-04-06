package com.a_lis.simplenotes;

import android.app.LoaderManager.LoaderCallbacks;
import android.content.Context;
import android.content.CursorLoader;
import android.content.Loader;
import android.os.Bundle;
import android.app.ListActivity;
import android.content.Intent;
import android.database.Cursor;
import android.util.Log;
import android.view.ContextMenu;
import android.view.ContextMenu.ContextMenuInfo;
import android.view.Menu;
import android.view.MenuItem;
import android.view.View;
import android.widget.AdapterView.AdapterContextMenuInfo;
import android.widget.ListView;
import android.widget.SearchView;
import android.widget.SimpleCursorAdapter;
import android.widget.Toast;

public class MainActivity extends ListActivity implements LoaderCallbacks<Cursor> {

    private DBTools dbHelper;
    private static final int ACTIVITY_CREATE = 0;
    private static final int ACTIVITY_EDIT = 1;
    private static final int DELETE_ID = Menu.FIRST + 1;
    SimpleCursorAdapter scAdapter;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_main);
        this.getListView().setDividerHeight(2);

        dbHelper = new DBTools(this);

        String[] from = new String[] { DBTools.COLUMN_TITLE, DBTools.COLUMN_DESCRIPTION};
        int[] to = new int[] { R.id.label, R.id.description };

        scAdapter = new SimpleCursorAdapter(this, R.layout.list_row,
                null, from, to, 0);
        setListAdapter(scAdapter);

        registerForContextMenu(getListView());

        Bundle bundle = new Bundle();
        bundle.putString("FILTER_QUERY", "");
        getLoaderManager().initLoader(0, bundle, this);
    }

    @Override
    public boolean onCreateOptionsMenu(Menu menu) {
        getMenuInflater().inflate(R.menu.main, menu);

        MenuItem searchItem = menu.findItem(R.id.search);
        SearchView searchView = (SearchView) searchItem.getActionView();

        searchView.setOnQueryTextListener(new SearchView.OnQueryTextListener() {
            @Override
            public boolean onQueryTextSubmit(String s) {
                Log.w(MainActivity.class.getName(), "onQueryTextSubmit(" + s + ")");
                Bundle bundle = new Bundle();
                bundle.putString("FILTER_QUERY", s);
                getLoaderManager().restartLoader(0, bundle, MainActivity.this);

                return false;
            }

            @Override
            public boolean onQueryTextChange(String s) {
                Log.w(MainActivity.class.getName(), "onQueryTextChange(" + s + ")");
                Bundle bundle = new Bundle();
                bundle.putString("FILTER_QUERY", s);
                getLoaderManager().restartLoader(0, bundle, MainActivity.this);
                return false;
            }
        });

        return true;
    }

    @Override
    public boolean onMenuItemSelected(int featureId, MenuItem item) {
        switch (item.getItemId()) {
            case R.id.insert:
                createNewNote();
                return true;

            case R.id.about:
                Toast.makeText(MainActivity.this, R.string.about_text, Toast.LENGTH_LONG).show();
        }
        return super.onMenuItemSelected(featureId, item);
    }

    @Override
    public boolean onOptionsItemSelected(MenuItem item) {
        switch (item.getItemId()) {
            case R.id.insert:
                createNewNote();
                return true;
        }
        return super.onOptionsItemSelected(item);
    }

    @Override
    public boolean onContextItemSelected(MenuItem item) {
        switch (item.getItemId()) {
            case DELETE_ID:
                AdapterContextMenuInfo info = (AdapterContextMenuInfo)item
                        .getMenuInfo();
                dbHelper.deleteNote(info.id);
                getLoaderManager().getLoader(0).forceLoad();
                return true;
        }
        return super.onContextItemSelected(item);
    }

    @Override
    public Loader<Cursor> onCreateLoader(int id, Bundle bundle) {
        return new MyCursorLoader(this, dbHelper, bundle.getString("FILTER_QUERY"));
    }

    @Override
    public void onLoadFinished(Loader<Cursor> loader, Cursor cursor) {
        scAdapter.swapCursor(cursor);
    }

    @Override
    public void onLoaderReset(Loader<Cursor> loader) {
    }

    static class MyCursorLoader extends CursorLoader {

        DBTools db;
        String query;

        MyCursorLoader(Context context, DBTools db, String query) {
            super(context);
            this.db = db;
            this.query = query;
        }

        @Override
        public Cursor loadInBackground() {
            return db.getDataByQuery(query);
        }
    }

    private void createNewNote() {
        Intent intent = new Intent(this, EditActivity.class);
        startActivityForResult(intent, ACTIVITY_CREATE);
    }

    @Override
    protected void onListItemClick(ListView l, View v, int position, long id) {
        super.onListItemClick(l, v, position, id);
        Intent intent = new Intent(this, EditActivity.class);
        intent.putExtra(DBTools.COLUMN_ID, id);
        startActivityForResult(intent, ACTIVITY_EDIT);
    }

    @Override
    protected void onActivityResult(int requestCode, int resultCode,
                                    Intent intent) {
        super.onActivityResult(requestCode, resultCode, intent);

        if (resultCode == RESULT_OK) {
            getLoaderManager().getLoader(0).forceLoad();
        }

    }

    @Override
    public void onCreateContextMenu(ContextMenu menu, View v,
                                    ContextMenuInfo menuInfo) {
        super.onCreateContextMenu(menu, v, menuInfo);
        menu.add(0, DELETE_ID, 0, R.string.action_delete);
    }

    @Override
    protected void onDestroy() {
        super.onDestroy();
        if (dbHelper != null) {
            dbHelper.close();
        }
    }
}