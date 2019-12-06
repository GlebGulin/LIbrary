import React, { Component } from 'react';
export class Orders extends Component {
    displayName = Orders.name
   
    constructor(props) {
        super(props);
        this.state = { forecasts: [], loading: true };

        fetch('order/gettaken')
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
                        <th>Взял</th>
                        <th>Дата и времяя</th>
                        
                    </tr>
                </thead>
                <tbody>
                    {forecasts.map(forecast =>
                        <tr key={forecast.bookName}>
                            <td>{forecast.bookName}</td>
                            <td>{forecast.regUserName}</td>
                            <td>{forecast.dateOrder}</td>
                        </tr>
                    )}
                </tbody>
            </table>
        );
    }

    render() {
        let contents = this.state.loading
            ? <p><em>Подключаетсся...</em></p>
            : Orders.renderForecastsTable(this.state.forecasts);

        return (
            <div>
                <h1>Книги на выдаче</h1>
               
                {contents}
            </div>
        );
    }
}
