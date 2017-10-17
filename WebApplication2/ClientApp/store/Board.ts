import { fetch, addTask } from 'domain-task';
import { Action, Reducer } from 'redux';
import { AppThunkAction } from './';
import { Board } from '../model/Board';

export interface BoardState {
    isLoading: boolean;
    boards: Board[];
}

interface RequestBoardsAction {
    type: 'REQUEST_BOARDS';
}

interface ReceivewBoardsAction {
    type: 'RECEIVE_BOARDS';
    boards: Board[];
}

type KnownAction = RequestBoardsAction | ReceivewBoardsAction;


export const actionCreators =
    {
        requestBoards: (): AppThunkAction<KnownAction> => (dispatch, getState) => {
            let fetchTask = fetch(`api/Board`)
                .then(response => response.json() as Promise<Board[]>)
                .then(data => {
                    dispatch({ type: 'RECEIVE_BOARDS', boards: data })
                });

            addTask(fetchTask);
        }
    };

const unloadedState: BoardState = { isLoading: false, boards: [] };

export const reducer: Reducer<BoardState> = (state: BoardState, incomingAction: Action) => {
    const action = incomingAction as KnownAction;
    switch (action.type) {
        case 'REQUEST_BOARDS':
            return {
                boards: state.boards,
                isLoading: true
            };
        case 'RECEIVE_BOARDS':
            return {
                boards: action.boards,
                isLoading: false
            }
        default:
            const exhaustiveCheck: never = action;
    }
    return state || unloadedState;
};