import React from 'react';
import Square from './square';

const Grid = (props) => {
	const renderSquare = (i) => {
		return <Square />;
	}

	return(
		<div className="editor-grid">
	        <div className="editor-grid-row">
	          {renderSquare(0)}
	          {renderSquare(1)}
	          {renderSquare(2)}
	          {renderSquare(3)}
	        </div>
		    <div className="editor-grid-row">
	          {renderSquare(4)}
	          {renderSquare(5)}
	          {renderSquare(6)}
	          {renderSquare(7)}
	        </div>
	        <div className="editor-grid-row">
	          {renderSquare(8)}
	          {renderSquare(9)}
	          {renderSquare(10)}
	          {renderSquare(11)}
	        </div>
	        <div className="editor-grid-row">
	          {renderSquare(12)}
	          {renderSquare(13)}
	          {renderSquare(14)}
	          {renderSquare(15)}
	        </div>
        </div>
	);
};


export default Grid;