import React from 'react';
import Grid from './grid';

const Editor = (props) => {


	return (
      <div className="editor">
      	<Grid />
        <div className="editor-info">
          <div>{/* status */}</div>
          <ol>{/* TODO */}</ol>
        </div>
      </div>
	);
}

export default Editor;