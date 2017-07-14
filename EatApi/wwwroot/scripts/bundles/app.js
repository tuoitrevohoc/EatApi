var appModule =
/******/ (function(modules) { // webpackBootstrap
/******/    // The module cache
/******/    var installedModules = {};
/******/
/******/    // The require function
/******/    function __webpack_require__(moduleId) {
/******/
/******/        // Check if module is in cache
/******/        if(installedModules[moduleId]) {
/******/            return installedModules[moduleId].exports;
/******/        }
/******/        // Create a new module (and put it into the cache)
/******/        var module = installedModules[moduleId] = {
/******/            i: moduleId,
/******/            l: false,
/******/            exports: {}
/******/        };
/******/
/******/        // Execute the module function
/******/        modules[moduleId].call(module.exports, module, module.exports, __webpack_require__);
/******/
/******/        // Flag the module as loaded
/******/        module.l = true;
/******/
/******/        // Return the exports of the module
/******/        return module.exports;
/******/    }
/******/
/******/
/******/    // expose the modules object (__webpack_modules__)
/******/    __webpack_require__.m = modules;
/******/
/******/    // expose the module cache
/******/    __webpack_require__.c = installedModules;
/******/
/******/    // define getter function for harmony exports
/******/    __webpack_require__.d = function(exports, name, getter) {
/******/        if(!__webpack_require__.o(exports, name)) {
/******/            Object.defineProperty(exports, name, {
/******/                configurable: false,
/******/                enumerable: true,
/******/                get: getter
/******/            });
/******/        }
/******/    };
/******/
/******/    // getDefaultExport function for compatibility with non-harmony modules
/******/    __webpack_require__.n = function(module) {
/******/        var getter = module && module.__esModule ?
/******/            function getDefault() { return module['default']; } :
/******/            function getModuleExports() { return module; };
/******/        __webpack_require__.d(getter, 'a', getter);
/******/        return getter;
/******/    };
/******/
/******/    // Object.prototype.hasOwnProperty.call
/******/    __webpack_require__.o = function(object, property) { return Object.prototype.hasOwnProperty.call(object, property); };
/******/
/******/    // __webpack_public_path__
/******/    __webpack_require__.p = "";
/******/
/******/    // Load entry module and return exports
/******/    return __webpack_require__(__webpack_require__.s = 0);
/******/ })
/************************************************************************/
/******/ ([
/* 0 */
/***/ (function(module, exports, __webpack_require__) {

"use strict";

var __awaiter = (this && this.__awaiter) || function (thisArg, _arguments, P, generator) {
    return new (P || (P = Promise))(function (resolve, reject) {
        function fulfilled(value) { try { step(generator.next(value)); } catch (e) { reject(e); } }
        function rejected(value) { try { step(generator["throw"](value)); } catch (e) { reject(e); } }
        function step(result) { result.done ? resolve(result.value) : new P(function (resolve) { resolve(result.value); }).then(fulfilled, rejected); }
        step((generator = generator.apply(thisArg, _arguments || [])).next());
    });
};
Object.defineProperty(exports, "__esModule", { value: true });
const React = __webpack_require__(1);
const ReactDOM = __webpack_require__(2);
const EatApiClient_1 = __webpack_require__(3);
const MenuComponent_1 = __webpack_require__(4);
const OrderComponent_1 = __webpack_require__(5);
class Application extends React.Component {
    constructor() {
        super(...arguments);
        this.state = { orders: [] };
        this.api = new EatApiClient_1.EatApiClient();
    }
    componentDidMount() {
        this.poolingForNewOrders();
    }
    poolingForNewOrders() {
        return __awaiter(this, void 0, void 0, function* () {
            try {
                let orders = yield this.api.getOrders();
                orders = orders.filter(order => !order.isReady).reverse();
                this.setState({ orders });
                setTimeout(() => this.poolingForNewOrders(), 5000);
            }
            catch (error) {
                console.log(error);
            }
        });
    }
    setOrderReady(order) {
        return __awaiter(this, void 0, void 0, function* () {
            order.isReady = true;
            const result = yield this.api.setOrderReady(order.id);
            this.setState({ message: "Order set ready!!" });
        });
    }
    render() {
        return (React.createElement("div", { className: "container" },
            React.createElement(MenuComponent_1.MenuComponent, null),
            React.createElement("div", { className: "order-list" }, "\u00A0"),
            this.state.message && (React.createElement("div", { className: "ui positive message" },
                React.createElement("i", { className: "close icon" }),
                React.createElement("div", { className: "header" }, this.state.message))),
            React.createElement("div", { className: "ui cards" }, this.state.orders.map((item, index) => (React.createElement(OrderComponent_1.OrderComponent, { key: item.id, queueNumber: (1000 + index).toString(), order: item, setOrderReady: (order) => this.setOrderReady(order) }))))));
    }
}
ReactDOM.render(React.createElement(Application, null), document.getElementById("root"));


/***/ }),
/* 1 */
/***/ (function(module, exports) {

module.exports = React;

/***/ }),
/* 2 */
/***/ (function(module, exports) {

module.exports = ReactDOM;

/***/ }),
/* 3 */
/***/ (function(module, exports, __webpack_require__) {

"use strict";

var __awaiter = (this && this.__awaiter) || function (thisArg, _arguments, P, generator) {
    return new (P || (P = Promise))(function (resolve, reject) {
        function fulfilled(value) { try { step(generator.next(value)); } catch (e) { reject(e); } }
        function rejected(value) { try { step(generator["throw"](value)); } catch (e) { reject(e); } }
        function step(result) { result.done ? resolve(result.value) : new P(function (resolve) { resolve(result.value); }).then(fulfilled, rejected); }
        step((generator = generator.apply(thisArg, _arguments || [])).next());
    });
};
Object.defineProperty(exports, "__esModule", { value: true });
class EatApiClient {
    constructor() {
        this.baseUrl = "";
    }
    getOrders() {
        return this.request("/api/orders");
    }
    setOrderReady(orderId) {
        return this.request("/api/orders/" + orderId, {
            body: "true",
            method: "PATCH"
        });
    }
    request(endPoint, options = {}) {
        return __awaiter(this, void 0, void 0, function* () {
            options.mode = 'cors';
            options.headers = {
                'Accept': 'application/json',
                'Content-Type': 'application/json'
            };
            const result = yield fetch(this.baseUrl + endPoint, options);
            return result.json();
        });
    }
}
exports.EatApiClient = EatApiClient;


/***/ }),
/* 4 */
/***/ (function(module, exports, __webpack_require__) {

"use strict";

Object.defineProperty(exports, "__esModule", { value: true });
const React = __webpack_require__(1);
class MenuComponent extends React.Component {
    render() {
        return (React.createElement("div", { className: "ui inverted primary fixed menu" },
            React.createElement("a", { className: "active item" }, "Home"),
            React.createElement("a", { className: "item" }, "Orders"),
            React.createElement("a", { className: "item" }, "Messages"),
            React.createElement("div", { className: "right menu" },
                React.createElement("div", { className: "item" },
                    React.createElement("div", { className: "ui icon input" },
                        React.createElement("input", { type: "text", placeholder: "Search..." }),
                        React.createElement("i", { className: "search link icon" }))),
                React.createElement("a", { className: "ui item" }, "Logout"))));
    }
}
exports.MenuComponent = MenuComponent;


/***/ }),
/* 5 */
/***/ (function(module, exports, __webpack_require__) {

"use strict";

Object.defineProperty(exports, "__esModule", { value: true });
const React = __webpack_require__(1);
class OrderComponent extends React.Component {
    render() {
        return (React.createElement("div", { className: "ui card" },
            React.createElement("div", { className: "content" },
                React.createElement("a", { className: "header" }, this.props.queueNumber),
                React.createElement("div", { className: "meta" },
                    React.createElement("span", { className: "date" },
                        this.props.order.items.reduce((a, b) => a + b.count, 0),
                        " Items")),
                React.createElement("div", { className: "description" },
                    React.createElement("table", { className: "ui table" },
                        React.createElement("tbody", null, this.props.order.items.map((item, index) => (React.createElement("tr", { key: index },
                            React.createElement("td", null, item.name),
                            React.createElement("td", null,
                                item.count,
                                " * $",
                                item.price)))))))),
            React.createElement("div", { className: "extra content" },
                React.createElement("a", { className: "ui button" + (this.props.order.isReady ? "positive" : ""), onClick: () => this.props.setOrderReady(this.props.order) },
                    React.createElement("i", { className: "check icon" }),
                    "This order is ready"))));
    }
}
exports.OrderComponent = OrderComponent;


/***/ })
/******/ ]);