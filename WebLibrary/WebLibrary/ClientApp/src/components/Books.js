import React, { Component } from 'react';
import Layout from './Layout';
export class Books extends Component {
    displayName = Books.name
//    render() {
//        return (
//            <div>
//                Список книг
//            </div>
//            );
//    }
//}
    constructor(props) {
        super(props);
        this.state = { forecasts: [], loading: true };
        
        fetch('library/getbooks')
            .then(response => response.json())
            .then(data => {
                this.setState({ forecasts: data, loading: false });
            });
    }

    static renderForecastsTable(forecasts) {
        return (
            
            <table className='table'>
                <thead>
                    <tr>
                        <th>Название книги</th>
                        <th>Авторы </th>
                        <th>Общее колличество</th>
                        <th>На остатке</th>
                    </tr>
                </thead>
                <tbody>
                    {forecasts.map(forecast =>
                        <tr key={forecast.nameBook}>
                            <td>{forecast.nameBook}</td>
                            <td>{forecast.authorName}</td>
                            <td>{forecast.totalQuantity}</td>
                            <td><button>Взять</button>{forecast.realQuantity}<button>Вернуть</button></td>
                        </tr>
                    )}
                </tbody>
            </table>
        );
    }

    render() {
        let contents = this.state.loading
            ? <p><em>Ожидайте...</em></p>
            : Books.renderForecastsTable(this.state.forecasts);

        return (
            <Layout>
            <div>
                <h1>Список книг</h1>
                
                {contents}
            </div>
            </Layout>
        );
    }
}
