import * as React from 'react';
import { Link, RouteComponentProps } from 'react-router-dom';
import { connect } from 'react-redux';
import { ApplicationState } from '../store';
import * as BoardState from '../store/Board';

type BoardProps =
    BoardState.BoardState
    & typeof BoardState.actionCreators
    & RouteComponentProps<{}>;

class Board extends React.Component<BoardProps, {}>
{
    componentWillMount()
    {
        this.props.requestBoards();
    }

    public render()
    {
        return <div>
            <h1> Boards </h1>
            <div>
                {this.renderBoardTable()}
            </div>
        </div>
    }

    private renderBoardTable()
    {
        if (this.props.isLoading)
        {
            return <span>Loading...</span>
        }
        else
        {
            return <table className='table'>
                <thead>
                    <tr>
                        <th>Name</th>
                        <th>Count</th>
                    </tr>
                </thead>
                <tbody>
                { this.props.boards.map(board =>
                    <tr key={board.Id}>
                        <td>{board.Name}</td>
                        <td>{board.Items.length}</td>
                    </tr>
                )}
                </tbody>
                </table>
        }
    }

    
};

export default connect(
    (state: ApplicationState) => state.board,
    BoardState.actionCreators
)(Board) as typeof Board;