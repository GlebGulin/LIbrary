import React, { Component } from 'react';
import './../../App.css';
import Reg from './Reg';
import { Button, Card, CardBody, CardGroup, Col, Container, Form, Input, InputGroup, InputGroupAddon, InputGroupText, Row } from 'reactstrap';
export class Login extends Component {
    // displayName = Login.name
    constructor() {
        super();
        this.state = {
            Email: '',
            Pass: ''
        }
        this.Pass = this.Pass.bind(this);
        this.Email = this.Email.bind(this);
        this.login = this.login.bind(this);
    }
    Email(event) {
        this.setState({ Email: event.target.value })
    }
    Pass(event) {
        this.setState({ Pass: event.target.value })
    }
    login(event) {
        
        fetch('/login', {
            method: 'post',
            headers: {
                'Accept': 'application/json',
                'Content-Type': 'application/json'
            },
            body: JSON.stringify({
                Email: this.state.Email,
                Pass: this.state.Pass
            })
        }).then((Response) => Response.json())
            .then((result) => {
                                if (result.status == 'Invalid')
                    alert('Не зарегестрированный пользователь');
                else
                    this.props.history.push("/library");
            })
    }
    render() {
        return (
            <div className="app flex-row align-items-center">
                <Container>
                    <Row className="justify-content-center">
                        <Col md="9" lg="7" xl="6">
                            <CardGroup>
                                <Card className="p-2">
                                    <CardBody>
                                        <Form>
                                            <div className="row mb-2 pageheading">
                                                <div class="col-sm-12 btn btn-primary">
                                                    Вход
                             </div>
                                            </div>
                                            <InputGroup className="mb-3">
                                                <Input type="text" onChange={this.Email} placeholder="Введите Почту" />
                                            </InputGroup>
                                            <InputGroup className="mb-4">
                                                <Input type="password" onChange={this.Pass} placeholder="Введите Пароль" />
                                            </InputGroup>
                                            <Button onClick={this.login} color="success" block>Войти</Button>
                                            <a href='/regist'>Зарегестрироваться</a>
                                            
                                        </Form>
                                    </CardBody>
                                </Card>
                            </CardGroup>
                        </Col>
                    </Row>
                </Container>
            </div>
        );
    }
}
